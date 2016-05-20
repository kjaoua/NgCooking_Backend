'use strict';

ngCooking.factory('authFact',[function(){
    var authfact ={};
    authfact.setAccessToken = function(accessToken){
        authfact.authToken = accessToken;
    };
    authfact.getAccessToken = function(){
        return  authfact.authToken;

    };
    return authfact;
}])
