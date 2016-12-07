var app = angular.module('Diamond');
app.run(function (tmhDynamicLocale) {    

    tmhDynamicLocale.set('pt-br');
    
})
.config(function (tmhDynamicLocaleProvider) {
    tmhDynamicLocaleProvider.localeLocationPattern("/Scripts/angular-locale_{{locale}}.env.js");
});