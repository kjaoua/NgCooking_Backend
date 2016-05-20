'use strict';
ngCooking.filter("recetteIngredientFilter",function(){
    return function(data,recetteIngredient){
        var Rctlist=[];
        var allFound = true;
        var existIng = false;
        if(data!=undefined){
            if(recetteIngredient!=undefined){
                // get ing list from string delimited by ';';
                var   ingList =   recetteIngredient.replace(/ /g,"").split(';');
             //parcourir la liste des recettes
                if(ingList[0]!=""){
                    for(var i =0;i<data.length;i++){
                        allFound = true;
                        //parcourir la liste des ingredients envoyé
                        for(var k =0;k<ingList.length;k++){
                            existIng = false;
                            for(var j = 0;j<data[i].ingredients.length;j++){
                                if(data[i].ingredients[j]==ingList[k]){
                                    existIng = true;
                                }
                            }
                          allFound = allFound&&existIng;
                      }
                      if(allFound){
                          Rctlist.push(data[i]);
                      }
                    }
                }else{
                    Rctlist = data;

                }
            }
            else {
                Rctlist = data;
            }
        }


           return Rctlist;
    }
});
