<%@ Page Language="c#" Codebehind="CustomPlugIn.aspx.cs" AutoEventWireup="False" Inherits="EpiserverTraining.Business.Plugin.CustomPlugIn" Title="" %>



    <h1>Welcome to the Custom Report Plugin</h1>
    <p>This is a demo plugin for custom reports. You can add your custom report generation logic here.</p>


 <h2>List of Child Pages of StartPage</h2>
    <ul>
        <% foreach (var childPage in Model.subPages)
           { %>
            <li><a href="<%= childPage.Url %>"><%= childPage.Name %></a></li>
        <% } %>
    </ul>