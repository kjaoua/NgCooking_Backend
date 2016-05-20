'use strict' ;
ngCooking.factory('getObjectService',function($http){
    var obj = {};
    obj.getObject = function(id,data){
         // getting object data from .json file
        var  objects = data;
        var counter = 0;

        var objectFound = false;
             // search object data among objects by Id
        while (counter <objects.length && !objectFound)
        {

            if (id == objects[counter].id)
            {
                objectFound = true;
                //return object
                return objects[counter];
            }
            counter++;
        }
    };
    return obj;

});