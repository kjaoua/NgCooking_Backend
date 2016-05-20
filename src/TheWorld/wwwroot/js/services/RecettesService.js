'use strict';

ngCooking.factory('getRecetteMark',function(){
    var obj ={};
    obj.averageMark = function(recette){
        var marks = 0;
        var average = 0;


        if(recette.comments.length != 0){
            for (var i =0;i<recette.comments.length;i++){
                marks+= recette.comments[i].mark  ;
            }

            average = marks/recette.comments.length;
        }
        return average;
    };
    return obj;
});
