'use strict' ;
ngCooking.factory('getJsonData',function($http){
    var dataPath = "/api/";
   // obj.test = " test retour réussi";
    var getdata = function(url){
        // getting users data from .json file
       return $http.get(url);
    };
    var getVarPath = function(file){return getdata(dataPath + file )};
    return {
        getCommunity: function () { return getVarPath('Communities'); },
        getCategories: function () { return getVarPath('Categories'); },
        getIngredients : function(){return getVarPath('Ingredients');},
        getRecettes : function(){return getVarPath('Recettes');},
    };
});