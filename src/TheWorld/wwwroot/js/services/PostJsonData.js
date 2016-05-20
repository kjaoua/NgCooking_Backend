'use strict';
ngCooking.factory('postJsonData', function ($http) {
    var dataPath = "/api/";
    // obj.test = " test retour réussi";
    var postdata = function (url,data) {
        // getting users data from .json file
        return $http.post(url,data);
    };
    var getVarPath = function (file) { return getdata(dataPath + file) };
    return {
        postCommunity: function () { return getVarPath('Communities'); },
        postCategories: function () { return getVarPath('Categories'); },
        postIngredients: function () { return getVarPath('Ingredients'); },
        postRecettes: function () { return getVarPath('Recettes'); },
    };
});