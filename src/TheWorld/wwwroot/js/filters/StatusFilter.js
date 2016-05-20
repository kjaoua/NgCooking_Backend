'use strict';
ngCooking.filter("statusFilter",function(){
    return function(status){
       switch (status){
           case 3:
               return "EXPERT";
           break;
           case 2:
               return "CONFIRME";
               break;
           case 1:
               return "NOVICE";
               break;
           default :
               return "NOVICE";

       }





    }
});