angular.module('myApp', ['smart-table'])
    .controller('mainCtrl', ['$scope', function ($scope) {

        var
            nameList = ['Pierre', 'Pol', 'Jacques', 'Robert', 'Elisa'],
            familyName = ['Dupont', 'Germain', 'Delcourt', 'bjip', 'Menez'];

        function createRandomItem() {
            var
                firstName = nameList[Math.floor(Math.random() * 4)],
                lastName = familyName[Math.floor(Math.random() * 4)],
                age = Math.floor(Math.random() * 100),
                email = firstName + lastName + '@whatever.com',
                balance = Math.random() * 3000;

            return{
                firstName: firstName,
                lastName: lastName,
                age: age,
                email: email,
                balance: balance
            };
        }


        $scope.displayed = [];
        for (var j = 0; j < 500; j++) {
            $scope.displayed.push(createRandomItem());
        }
    }])
    .directive('stRatio',function(){
        return {
          link:function(scope, element, attr){
            var ratio=+(attr.stRatio);
            
            element.css('width',ratio+'%');
            
          }
        };
    });

