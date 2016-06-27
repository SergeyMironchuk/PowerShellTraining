<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PowerShell.aspx.cs" Inherits="PowerShell.WebUI.PowerShell" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/kendo/kendo.common.min.css" rel="stylesheet" type="text/css" />
    <link href="/Content/kendo/kendo.bootstrap.min.css" rel="stylesheet" type="text/css" />

    <%--<script src="/js/kendo/jquery.min.js" type="text/javascript"></script>--%>
    <script src="/Scripts/kendo/angular.min.js" type="text/javascript"></script>
    <script src="/Scripts/kendo/kendo.ui.core.min.js" type="text/javascript"></script>
    <script src="/Scripts/kendo/kendo.angular.min.js" type="text/javascript"></script>
    
    <div id="ng-app" ng-app="PowerShell">
        <div ng-controller="PowerShellCtrl" style="padding: 5px;">
            <input type="text" ng-model="command" class="k-textbox" style="width: 400px;"/>
            <button ng-click="runCommand()" class="k-button" type="button">RUN</button>
            <br/>
            <div ng-repeat="result in resultList" style="position: relative;">
                <span>{{ result }}</span><br/>
            </div>
            <span kendo-notification="notification" k-button="true" k-auto-hide-after="10000"></span>
        </div>

        <script type="text/javascript">
            angular.module("PowerShell", ["kendo.directives"])
            .controller("PowerShellCtrl", function ($scope, $http) {
                $scope.resultList = [1,2,3];

                $scope.runCommand = function() {
                    $http.post('PowerShellApi/Run?Command='+$scope.command).
                    success(function (data) {
                        $scope.resultList = data;
                    }).
                    error(function (result) {
                        $scope.notification.info("Ошибка");
                    });
                }
            })
        </script>
    </div>
</asp:Content>
