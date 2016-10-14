<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="javascriptDemo.aspx.cs" Inherits="javascriptLibaray.javascriptDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script>
        //var test;
        //console.log(typeof (test));
        //var test1 = null;
        //console.log(typeof(test1));
        //var test2 = new Object();
        //console.log(typeof (test2));
        //var arr = [1, 2, 3];
        //console.log(arr);
        //var arr1 = new Array(1, 2, 3, 4);
        //console.log(arr1);

        //var person = {
        //    name: "",
        //    tags: ['js', 'web'],
        //    zipcode:null
        //};
        //console.log(person);

        //var o = {
        //    name: 'Jack',
        //    age: 20,
        //    city: 'Beijing'
        //};

        //for (var key in o) {
        //    //alert(key); // 'name', 'age', 'city'
        //    //alert(o.name);
        //    //alert(o.age);
        //    //alert(o.city);
        //}

        //function abs(x) {
        //    for (var i = 0; i < arguments.length; i++) {
        //       // alert(arguments[i]);
        //    }
        //}

        ////var absn = function (x) {
        ////    for (var i=0; i<arguments.length; i++) {
        ////        alert(arguments[i]);
        ////    };

        //abs(10, 20, 30);

        //function lazy_sum(arr) {
        //    var sum = function () {
        //        return arr.reduce(function (x, y) {
        //            return x + y;
        //        });
        //    }
        //    return sum;
        //}

        //var f = lazy_sum([1, 2, 3, 4, 5]);
        //console.log(f);
        //var result = f();
        //console.log(result);


        //var f1 = lazy_sum([1, 2, 3, 4, 5]);
        //var f2 = lazy_sum([1, 2, 3, 4, 5]);
        //if(f1 == f2)
        //{
        //    console.log("true");
        //}
        //else
        //{
        //    console.log("false");
        //}


        //function count() {
        //    var arr = [];
        //    for (var i = 1; i <= 3; i++) {
        //        arr.push(function () {
        //            return i * i;
        //        });
        //    }
        //    return arr;
        //}

        //var results = count();
        //var f1 = results[0];
        //var f2 = results[1];
        //var f3 = results[2];
        //console.log(f1());
        //console.log(f2());
        //console.log(f3());


        //(function (x) {
        //    console.log(x * x);
        //})(3);


        //var arr = [1, 2, 3];
        //var o = null;
        //console.log(arr.prototype);
        //console.log(arr.prototype);
        //console.log(Array.prototype);

        //if (arr.hasOwnProperty)
        //{
        //    console.log("true")
        //}
        //else
        //{
        //    console.log("false");
        //}

        //console.log(arr)

        // function foo()
        // {
        //     return 0;
        // }

        // console.log(foo.prototype);

        // var o = new Object();
        //// console.log(o.prototype);
        // console.log(o.hasOwnProperty());

        //function siteAdmin(nickName, siteName) {
        //    this.nickName = nickName;
        //    this.siteName = siteName;
        //    this.showFunction = function () {
        //        alert("11");
        //    }
        //}
        //siteAdmin.prototype.showAdmin = function () {
        //    alert(this.nickName + "是" + this.siteName + "的站长!")
        //};
        //siteAdmin.prototype.showSite = function (siteUrl) {
        //    this.siteUrl = siteUrl;
        //    return this.siteName + "的地址是" + this.siteUrl;
        //};

        //var matou = new siteAdmin("脚本之家", "WEB前端开发");
        //var matou2 = new siteAdmin("脚本之家", "WEB前端开发");
        //matou.age = "30";


        ////alert(matou.hasOwnProperty("nickName"));//true
        ////alert(matou.hasOwnProperty("age"));//true
        ////alert(matou.hasOwnProperty("showAdmin"));//false
        //console.log(siteAdmin.prototype);
        //console.log(matou.prototype);
        //console.log(matou.hasOwnProperty("nickName"));//false
        //console.log(matou.hasOwnProperty("showFunction"));
        //console.log(siteAdmin.prototype.hasOwnProperty("nickName"));
        //console.log(siteAdmin.prototype.hasOwnProperty("showFunction"));
        //alert(siteAdmin.prototype.hasOwnProperty("showAdmin"));//true
        //alert(siteAdmin.prototype.hasOwnProperty("siteUrl"));//false
        //alert(siteAdmin.prototype.isPrototypeOf(matou))//true
        //alert(siteAdmin.prototype.isPrototypeOf(matou2))//true


        //function baseClass() {
        //    this.showMsg = function () {
        //        alert("baseClass::showMsg");
        //    }
        //}

        //function extendClass() {
        //    //this.showMsg = function () {
        //    //    //alert("extendClass::showMsg");
        //    //}
        //}

        //extendClass.prototype = new baseClass();
        //var instance = new extendClass();
        //instance.showMsg(); // 显示baseClass::showMsg
        //function f1() { };
        //var f2 = function () { };
        //var f3 = new Function('str', 'console.log(str)');

        //var o3 = new f1();
        //var o1 = {};
        //var o2 = new Object();

        ////console.log(typeof Object); //function
        ////console.log(typeof Function); //function
        ////console.log(typeof o1); //object
        ////console.log(typeof o2); //object
        ////console.log(typeof o3); //object
        ////console.log(typeof f1); //function
        ////console.log(typeof f2); //function
        ////console.log(typeof f3); //function 

        //var i = 0;
        //console.log(i.protoype);
        //var ne = new f1();
        //console.log(ne.prototype);
        //console.log(f1.prototype);

        //function f1() { };
        //console.log(f1.prototype) //f1{}
        //console.log(typeof f1.prototype) //Object
        //console.log(typeof Function.prototype) // Function，这个特殊
        //console.log(typeof Object.prototype) // Object
        //console.log(typeof Function.prototype.prototype) //undefined
        //function callback() {
        //    console.log('Done');
        //}
        //console.log('before setTimeout()');
        //setTimeout(callback, 1000); // 1秒钟后调用callback函数
        //console.log('after setTimeout()');
        //'use strict';

        //new Promise(function () { });

        //function test(resolve, reject) {
        //    var timeOut = Math.random() * 2;
        //    console.log('set timeout to: ' + timeOut + ' seconds.');
        //    setTimeout(function () {
        //        if (timeOut < 1) {
        //            conole.log('call resolve()...');
        //            resolve('200 OK');
        //        }
        //        else {
        //            console.log('call reject()...');
        //            reject('timeout in ' + timeOut + ' seconds.');
        //        }
        //    }, timeOut * 1000);
        //}

        //var p1 = new Promise(test);
        ////var p2 = p1.then(function (result) {
        ////    console.log('成功：' + result);
        ////});
        ////var p3 = p2.catch(function (reason) {
        ////    console.log('失败：' + reason);
        ////});
        //p1.then(function (result) { console.log('成功' + result); }).catch(function (reson) { console.log('失败' + reson); });

        // use strict';

        //// 清除log:
        //var logging = document.getElementById('test-promise-log');
        ////while (logging.children.length > 1) {
        ////    logging.removeChild(logging.children[logging.children.length - 1]);
        ////}

        //// 输出log到页面:
        //function log(s) {
        //    var p = document.createElement('p');
        //    p.innerHTML = s;
        //    logging.appendChild(p);
        //}

        //new Promise(function (resolve, reject) {
        //    log('start new Promise...');
        //    var timeOut = Math.random() * 2;
        //    log('set timeout to: ' + timeOut + ' seconds.');
        //    setTimeout(function () {
        //        if (timeOut < 1) {
        //            log('call resolve()...');
        //            resolve('200 OK');
        //        }
        //        else {
        //            log('call reject()...');
        //            reject('timeout in ' + timeOut + ' seconds.');
        //        }
        //    }, timeOut * 1000);
        //}).then(function (r) {
        //    log('Done: ' + r);
        //}).catch(function (reason) {
        //    log('Failed: ' + reason);
        //});

    </script>
     <script src="Scripts/knockout-3.4.0.js"></script>
      
  
</head>
<body>
    <form id="form1" runat="server">
        <div id="test-promise-log">
        </div>

        <p>First name:
            <input data-bind="value: firstName" /></p>
        <p>Last name:
            <input data-bind="value: lastName" /></p>
        <h2>Hello, <span data-bind="text: fullName"></span>!</h2>

    </form>
     
</body>

    <script>
        // Here's my data model
        var ViewModel = function (first, last) {
            this.firstName = ko.observable(first);
            this.lastName = ko.observable(last);

            this.fullName = ko.pureComputed(function () {
                // Knockout tracks dependencies automatically. It knows that fullName depends on firstName and lastName, because these get called when evaluating fullName.
                return this.firstName() + " " + this.lastName();
            }, this);
        };

        ko.applyBindings(new ViewModel("Planet", "Earth")); // This makes Knockout get to work

      </script>
</html>
