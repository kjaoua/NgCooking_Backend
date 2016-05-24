'use strict';
ngCooking.factory('postJsonData', function ($http) {
    var dataPath = "/api/";
    // obj.test = " test retour réussi";
    var postdata = function (url,data) {
        // getting users data from .json file
        //return $.ajax({
        //    type: "POST",
        //    data: JSON.stringify(data),
        //    url: url,
        //    contentType: "application/json"
        //});
        return $http.post(url, JSON.stringify(data));
    };
    var getVarPath = function (file,data) { return postdata(dataPath + file,data) };
    return {
        postCommunity: function (data) { return getVarPath('Communities',data); },
        postCategories: function (data) { return getVarPath('Categories',data); },
        postIngredients: function (data) { return getVarPath('Ingredients',data); },
        postRecettes: function (data) { return getVarPath('Recettes',data); },
    };
});