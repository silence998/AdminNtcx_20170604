using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;  
using System.Configuration.Provider;  
using System.Collections.Specialized;  
using System.Data;  
using System.Data.SqlClient;  
using System.Configuration;  
using System.Diagnostics;  
using System.Globalization;  
using System.Web.Configuration;



namespace AdminNtcx.WebUI.Helper
{
    public class CustomRoleProvider : RoleProvider
    {
       public override string[] GetRolesForUser(string username)
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string role = ticket.UserData;
            return role.Split(',');
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Web.Security.RoleProvider class.
        public CustomRoleProvider()
        {

        }
        public override string ApplicationName { get; set; }

        //
        // Summary:
        //     Gets or sets the name of the application to store and retrieve role information
        //     for.
        //
        // Returns:
        //     The name of the application to store and retrieve role information for.
        //public abstract string ApplicationName { get; set; }

        //
        // Summary:
        //     Adds the specified user names to the specified roles for the configured applicationName.
        //
        // Parameters:
        //   usernames:
        //     A string array of user names to be added to the specified roles.
        //
        //   roleNames:
        //     A string array of the role names to add the specified user names to.
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {

        }
        //
        // Summary:
        //     Adds a new role to the data source for the configured applicationName.
        //
        // Parameters:
        //   roleName:
        //     The name of the role to create.
        public override void CreateRole(string roleName)
        {

        }
        //
        // Summary:
        //     Removes a role from the data source for the configured applicationName.
        //
        // Parameters:
        //   roleName:
        //     The name of the role to delete.
        //
        //   throwOnPopulatedRole:
        //     If true, throw an exception if roleName has one or more members and do not delete
        //     roleName.
        //
        // Returns:
        //     true if the role was successfully deleted; otherwise, false.
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            return false;
        }
        //
        // Summary:
        //     Gets an array of user names in a role where the user name contains the specified
        //     user name to match.
        //
        // Parameters:
        //   roleName:
        //     The role to search in.
        //
        //   usernameToMatch:
        //     The user name to search for.
        //
        // Returns:
        //     A string array containing the names of all the users where the user name matches
        //     usernameToMatch and the user is a member of the specified role.
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return null;
        }
    //
    // Summary:
    //     Gets a list of all the roles for the configured applicationName.
    //
    // Returns:
    //     A string array containing the names of all the roles stored in the data source
    //     for the configured applicationName.
        public override string[] GetAllRoles()
        {
            return null;
        }
        //
        // Summary:
        //     Gets a list of the roles that a specified user is in for the configured applicationName.
        //
        // Parameters:
        //   username:
        //     The user to return a list of roles for.
        //
        // Returns:
        //     A string array containing the names of all the roles that the specified user
        //     is in for the configured applicationName.
        //public string[] GetRolesForUser(string username);
        //
        // Summary:
        //     Gets a list of users in the specified role for the configured applicationName.
        //
        // Parameters:
        //   roleName:
        //     The name of the role to get the list of users for.
        //
        // Returns:
        //     A string array containing the names of all the users who are members of the specified
        //     role for the configured applicationName.
        public override string[] GetUsersInRole(string roleName)
        {
            return null;
        }
        //
        // Summary:
        //     Gets a value indicating whether the specified user is in the specified role for
        //     the configured applicationName.
        //
        // Parameters:
        //   username:
        //     The user name to search for.
        //
        //   roleName:
        //     The role to search in.
        //
        // Returns:
        //     true if the specified user is in the specified role for the configured applicationName;
        //     otherwise, false.
        public override bool IsUserInRole(string username, string roleName)
        {
            return false;
        }
        //
        // Summary:
        //     Removes the specified user names from the specified roles for the configured
        //     applicationName.
        //
        // Parameters:
        //   usernames:
        //     A string array of user names to be removed from the specified roles.
        //
        //   roleNames:
        //     A string array of role names to remove the specified user names from.
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {

        }
        //
        // Summary:
        //     Gets a value indicating whether the specified role name already exists in the
        //     role data source for the configured applicationName.
        //
        // Parameters:
        //   roleName:
        //     The name of the role to search for in the data source.
        //
        // Returns:
        //     true if the role name already exists in the data source for the configured applicationName;
        //     otherwise, false.
        public override bool RoleExists(string roleName)
        {
            return false;
        }

    }
}