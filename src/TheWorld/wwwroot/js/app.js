'use strict' ;

var ngCooking = angular.module("ngCooking",['ngRoute', 'ngCookies']);
// configure our routes
ngCooking.config(function($routeProvider) {
    $routeProvider

    // route for the home page
        .when('/', {
            templateUrl : 'home.html',
            controller  : 'homeCTRL'
        })

        // route for the communaute page
        .when('/communaute', {
            templateUrl : 'communaute.html',
            controller  : 'communauteCTRL'
        })
        .when('/communaute_details', {
            templateUrl : 'communaute_details.html',
            controller  : 'communaute_detailsCTRL'
        })

        // route for the ingredients page
        .when('/ingredients', {
            templateUrl : 'ingredients.html',
            controller  : 'ingredientsCTRL'
        })
        // route for the recettes page
        .when('/recettes', {
            templateUrl : 'recettes.html',
            controller  : 'recettesCTRL'
        })
        // route for the ingredients page
        .when('/monProfil', {
            resolve:{
                "check": function($location,$rootScope){
                    if(!$rootScope.loggedIn){
                        $location.path('#/');
                        console.log('statut non conecté');
                    }
                    else {

                        console.log('statut connecté' )
                    }
                }
            },
            templateUrl : 'monProfil.html'
            //authenticated : true
        })
        // route for the recettes page
        .when('/recettes_details', {
            templateUrl : 'recettes_details.html',
            controller  : 'recettes_detailsCTRL'
        })
        // route for the recettes page
        .when('/recettes_new', {
            templateUrl : 'recettes_new.html',
            controller  : 'recette_newCTRL',
            authenticated : true
        })
        .when('/inscription', {
            templateUrl: 'inscription.html',
            controller: 'inscriptionCTRL',
            authenticated: true
        })
        
        .otherwise({
            templateUrl : 'home.html',
            controller  : 'homeCTRL'
        })

});
ngCooking.controller("homeCTRL", function($scope,$location) {
    // create a message to display in our view
    $scope.Pages = [
        {
            name : 'Home',
            class : 'page_hom',
            ref :'#/'
        },
        {
            name : 'Recettes',
            class : 'page_rec',
            ref :'#/recettes'

        },
        {
            name : 'Ingredients',
            class : 'page_ing',
            ref :'#/ingredients'

        },
        {
            name : 'Communauté',
            class : 'page_com',
            ref :'#/communaute'

        }
    ];
    var location = $location.url();
    $scope.pageCourante = null;

    switch (location){
        case '/' :
            $scope.pageCourante = $scope.Pages[0];
            break;
        case '/recettes' :
            $scope.pageCourante = $scope.Pages[1];
            break;
        case '/recettes_details' :
            $scope.pageCourante = $scope.Pages[1];
            break;
        case '/recettes_new' :
            $scope.pageCourante = $scope.Pages[1];
            break;
        case '/ingredients' :
            $scope.pageCourante = $scope.Pages[2];
            break;
        case '/communaute' :
            $scope.pageCourante = $scope.Pages[3];
            break;
        case '/communaute_details' :
            $scope.pageCourante = $scope.Pages[3];
            break;
        default :
            $scope.pageCourante = $scope.Pages[0];
            break;
    }
    console.log('je suis dans la page :'+ $location.url());
    $scope.selectPage = function(page){
        $scope.pageCourante = page;
    };
});
ngCooking.controller("communauteCTRL", function($scope,getJsonData,$cookies) {

    getJsonData.getCommunity().then(function(response)
    {   
        $scope.communities = response.data;
    });
    $scope.dispNbre=10;
    $scope.dispMore = function(){
          $scope.dispNbre+=10;
     };

     //get users recettes
     getJsonData.getRecettes().then(function(response1){
        for (var j =0;j<$scope.communities.length;j++){
             var nbreRct = 0;
             for (var k=0;k<response1.data.length;k++){
                  if(response1.data[k].creatorId == $scope.communities[j].id){
                        nbreRct++;
                   }
              }
              $scope.communities[j].nbreRct = nbreRct;

        }
     });
    $scope.getStars = function(number){
        var table=[];
        for (var i=0;i<number;i++){
            table.push(i);
        }
        return table;
    };
    $scope.getSmallImg = function(path){
        return path.substring(0,path.length-4)+'_small.jpg';
    };
    $scope.setUser= function(id){
        $cookies.remove('clickeduserId');
        $cookies.put('clickeduserId',id);
    };
    $scope.selectOption ='firstname';

});
ngCooking.controller("communaute_detailsCTRL", function($scope,$http,getJsonData,$cookies,getObjectService,getRecetteMark) {

    $scope.usrId = $cookies.get('clickeduserId');
    $scope.nbRct = 0;
    $scope.userRecettes =[];
    //get user recettes
    getJsonData.getRecettes().then(function(response){
        for (var k=0;k<response.data.length;k++){
            if(response.data[k].creatorId == $scope.usrId){
                $scope.nbRct++;
                $scope.userRecettes.push(response.data[k]);
            }

        }

    });

    getJsonData.getCommunity().then(function(response)
    {
        //$scope.communities =response.data ;
        $scope.user= getObjectService.getObject($scope.usrId,response.data);
        var year = new Date().getFullYear();
        $scope.age = year - $scope.user.birth;
    });
    $scope.getStars = function(number){
        var table=[];
        for (var i=0 ; i<number ;i++){
            table.push(i);
        }
        return table;
    };
    $scope.averageMark = function(recette){
        return  getRecetteMark.averageMark(recette);
    }


});
ngCooking.controller("ingredientsCTRL", function($scope,getJsonData) {
    getJsonData.getIngredients().then(function(response)
    {   $scope.dispNbre=10;
        $scope.ingredients = response.data;


    });
    getJsonData.getCategories().then(function(response) {
        $scope.categories = response.data;
        $scope.allCategory = $scope.categories[0];
        $scope.allCategory.id = 'all';
        $scope.allCategory.nameToDisplay ='Toutes les catégories';
    });
    $scope.dispMore = function(){
        $scope.dispNbre+=10;
    };
    $scope.filtered = [];
    $scope.setCategory = function(category){
        if(category.id=="all"){
            $scope.selectedCategory = null;
        }
        else{
            $scope.selectedCategory =category;
        }
        console.log('la category selectionnée est: '+ category.id);


    };

});
ngCooking.controller("recettesCTRL", function($scope, $http,getJsonData,getRecetteMark,$cookies,$route) {
    getJsonData.getRecettes().then(function(response)
    {
        $scope.recettes =response.data;
        for(var i = 0 ; i<$scope.recettes.length ;i++){
            $scope.recettes[i].averageMark = getRecetteMark.averageMark($scope.recettes[i]);
        }
    });
    $scope.selectOption = "name";
    $scope.dispNbre=4;
    $scope.filtered = [];
    $scope.recetteFound = false;
    $scope.dispMore = function(){
        $scope.dispNbre+=4;
    };
    $scope.setRecette = function(recetteId){
        $cookies.remove('clickedRecette');
        $cookies.put('clickedRecette',recetteId);
        console.log('La recette cliqué: ' +$cookies.get('clickedRecette'));
        $route.reload();
    };



    $scope.getTable = function(number){
        var table = [];
        var i = 1;
        while(i<=Math.round(number)){
            table.push(i);
            i++;

        }
        return table;
    };


});
ngCooking.controller("recettes_detailsCTRL", function($scope,getObjectService, $http,getJsonData,getRecetteMark,$cookies,$route) {

    getJsonData.getRecettes().then(function(response)
    {
        $scope.recettes =response.data;
        for(var k = 0 ;k<$scope.recettes.length ;k++){
            $scope.recettes[k].averageMark = getRecetteMark.averageMark($scope.recettes[k]);
        }
        for(var i = 0 ; i<$scope.recettes.length ; i++){
            if($scope.recettes[i].comments){
                $scope.recettes[i].commentsNbr =$scope.recettes[i].comments.length

            }
            else{
                $scope.recettes[i].commentsNbr =0;
            }
        }
        $scope.recetteId = $cookies.get('clickedRecette');
       
        $scope.recette = getObjectService.getObject($scope.recetteId,$scope.recettes);
        getJsonData.getIngredients().then(function(response1){
            $scope.recette.ingredientsList =[];
            for(var j= 0;j<$scope.recette.ingredients.length;j++){
                $scope.recette.ingredientsList[j] = getObjectService.getObject($scope.recette.ingredients[j],response1.data);

            }
            $scope.getCalories= function () {
                var sumCalories = 0;
                if($scope.recette.ingredientsList != undefined){
                    for(var x=0;x<$scope.recette.ingredientsList.length;x++ ){
                        sumCalories+=$scope.recette.ingredientsList[x].calories;
                    }
                    sumCalories =   sumCalories/$scope.recette.ingredientsList.length;
                }

                return sumCalories;

            };

        });
    });
    getJsonData.getCommunity().then(function(response)
    {
        $scope.getUserName = function(userId){
            var user = getObjectService.getObject(userId,response.data);
            return user.firstname +' '+ user.surname;

        };
        $scope.setUser= function(id){
            $cookies.remove('clickeduserId');
            $cookies.put('clickeduserId',id);
            $route.reload();
        };

    });



    $scope.validationStatus = false;
    $scope.setValidationStatus = function(value){
        $scope.validationStatus = value;
    };
    $scope.getStars = function(number){
        var table=[];
        for (var i=0;i<Math.round(number);i++){
            table.push(i);
        }
        return table;
    };
    $scope.dispNbre=5;

    $scope.dispMore = function(){
        $scope.dispNbre+=5;
    };
});
ngCooking.controller("recette_newCTRL",function($scope,getJsonData,$http){
    getJsonData.getCategories().then(function(response) {
        $scope.categories = response.data;

        getJsonData.getIngredients().then(function(response1) {
            for(var j =0;j<$scope.categories.length;j++){
                $scope.categories[j].ingredients =[];
                for(var i = 0;i<response1.data.length;i++){
                    if   ($scope.categories[j].name==response1.data[i].category.name){
                        $scope.categories[j].ingredients.push(response1.data[i]);
                    }
                }
            }

        });
        //$scope.selectedCategory = $scope.categories[0];
        $scope.setCategory = function(category){
            $scope.selectedCategory =category;
            console.log('la category selectionné est: '+ category.id);
        };
        $scope.setIngredient = function(ing){
            $scope.selectedingredient =ing;
            console.log('ingredient selectionné');

        };
        $scope.ingredientList = [];
        $scope.addIngredient = function(ingredient){
            var exist=false;
            for(var i =0;i<$scope.ingredientList.length;i++){
                if($scope.ingredientList[i].id==ingredient.id){
                    exist = true;
                }
            }
            if(!exist){
                $scope.ingredientList.push(ingredient);
                console.log('ingredient : '+ingredient.id+'  ajouté avec succés');
            }
            else{
                console.log('ingredient : '+ingredient.id+'  existe déja');
            }
        };
        $scope.removeIngredient = function(ingredient){
            var deleted = false;
            var counter =0;
            while((counter<$scope.ingredientList.length)&& !deleted){
                if(ingredient.id == $scope.ingredientList[counter].id){
                    $scope.ingredientList.splice(counter,1);
                    deleted = true;

                }
                counter++;
            }
            console.log('ingredient : '+ingredient.id+'  supprimé avec succés');



        };
        $scope.getCalories= function () {
            var sumCalories = 0;

            if($scope.ingredientList != undefined){
                for(var x=0;x<$scope.ingredientList.length;x++ ){
                    sumCalories+= $scope.ingredientList[x].calories;
                }
                sumCalories =   sumCalories/$scope.ingredientList.length;
            }

            return sumCalories;

        };
        $scope.validationStatus = "notMontionned";
        $scope.submit=function(){
            if(($scope.ingredientList.length >2)&&($scope.ingredientList.length<=10)){
                
                //$http.post("/api/Categories", $scope.categories).success(function () {
                //    console.log("post categories");
               
                //})
                $scope.validationStatus = "validated";
            }else{
                $scope.validationStatus ="notValidated";
            }
        };
        $scope.setValidationStatus=function(){
            $scope.validationStatus = "notMontionned";

        };

    });

});
ngCooking.controller("monProfilCTRL", function($scope,$cookies,$http, getObjectService,getJsonData,getRecetteMark) {
//get user id from cookies
    $scope.usrId = $cookies.get('id') ;
    $scope.nbRct = 0;
    $scope.userRecettes =[];
    getJsonData.getRecettes().then(function(response){
        for (var k=0;k<response.data.length;k++){
            if(response.data[k].creatorId == $scope.usrId){
                $scope.nbRct++;
                $scope.userRecettes.push(response.data[k]);
            }

        }

    });
    getJsonData.getCommunity().then(function(response){
        // get user data from getObjectService

        $scope.user = getObjectService.getObject($scope.usrId,response.data);
        var year = new Date().getFullYear();
        $scope.age = year - $scope.user.birth;
        $scope.getStars = function(number){
            var table=[];
            for (var i=0;i<number;i++){
                table.push(i);
            }
            return table;
        };
        $scope.averageMark = function(recette){
            return  getRecetteMark.averageMark(recette);
        }

    });
    $scope.setRecette = function(recetteId){
        $cookies.remove('clickedRecette');
        $cookies.put('clickedRecette',recetteId);
        console.log('La recette cliqué: ' +$cookies.get('clickedRecette'));
    };
});

ngCooking.controller("HomeController", function HomeController($scope, $http,getJsonData,getRecetteMark,$cookies){


});
ngCooking.controller("inscriptionCTRL", function ($scope, $http, $location, $cookies, $rootScope, fileUpload, $route, postJsonData) {
    $scope.newUsername = $cookies.get('newUsername');
    $scope.newPassword = $cookies.get('newPassword');
    $scope.newUser = [{}];
    $scope.errorInscriptionMessage = "";
    $scope.validationStatus = "notMontionned";
    $scope.disableSubmit = false;
    $scope.uploadFile = function () {
        var file = $scope.myFile;

        console.log('file is ');
        console.dir(file);

        var uploadUrl = "/api/Communities";
        fileUpload.uploadFileToUrl(file, uploadUrl);
    };
    $scope.submit = function () {
        $scope.newUser = [{
            "firstname": $scope.firstname,
            "surname": $scope.surname,

            "email": $scope.newUsername,
            "password": $scope.newPassword,
            "level": $scope.selectLevel,
            "picture": "img/users/" + $scope.myFile.name,
            "city": $scope.city,
            "birth": $scope.birth,
            "bio": $scope.bio
        }];
        console.debug($scope.newUser);
        $scope.disableSubmit = true;
        postJsonData.postCommunity($scope.newUser).success(function (res) {
            console.log('res', res);
            if (res) {
                //console.log('connexion reussi pour: ' + $scope.firstname + ' ' + $scope.surname);
               $scope.validationStatus = "validated";
               
               $scope.disableSubmit = true;
                console.log('inscription reussi pour: ' + $scope.firstname + ' ' + $scope.surname);
                console.log($scope.validationStatus);
               
            }
            else {
                $scope.validationStatus = "notvalidated";
                $scope.errorInscriptionMessage = "Merci de vérifier les données entrées";

                $scope.disableSubmit = false;

            }
        }).error(function (res) {
            $scope.validationStatus = "notvalidated";
            $scope.disableSubmit = false;

            $scope.errorInscriptionMessage = "Merci de vérifier les données entrées: veuillez entrez un nouveau email";
        });
    };
    

});
