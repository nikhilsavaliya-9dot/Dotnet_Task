namespace test.Helpers
{
    public class ResponseMessage
    {
        // Comman
        public static string DataRetrieved = "Data has been successfully retrieved.";
        public static string DataNotFound = "No data found. Please try again later.";
        public static string SomethingWentWrong = "something went wrong.";
        public static string UserNotFound = "We're sorry, but the user you are looking for could not be found in our system.";
        public const string SelectFileOne = "Please select only one file.";
        public static string ValidEmailAddress = "The email address you entered is invalid. Please provide a valid email address.";
        public static string AccessRestricted = "Access restricted to authorized personnel. Please contact the administrator for further assistance.";
        public static string UserInActive = "The user account is inactive. Please contact the administrator for assistance.";
        public static string PasswordNotMatch = "The password you entered is incorrect. Please try again.";
        public static string EmailNotVerify = "Your email address has not been verified. Please check your inbox and verify your email to proceed.";
        public static string EmailVerify = "Your email address has been verified successfully.";
        public static string OTPNotSend = "OTP not send please try again.";
        public static string OTPSend = "OTP was sent successfully to your email address.";
        public const string ReferralCodeNotFound = "Invalid referral code.";
        public const string InsufficientPermissions = "You do not have sufficient permissions to perform this action. Only Admin and IB roles are allowed.";
        public static string EmailVerification = "Send email verification successfully.";
        public static string UpdateUser = "Your profile updated successfully.";
        public static string PasswordDetails = "The user name and password have been sent successfully.";
        public static string PasswordVerification = "Success Password verification.";
        public static string LogoutSuccess = "You have successfully logged out.";

        // Auth
        public static string IncorrectPassword = "The password you entered is incorrect. Please try again.";
        public static string LoginSuccessfully = "Login successfully.";


      

        //User Master
        public static string EmailOrPhoneExists = "Email or Phone Number already exists.";
        public static string EmailExists = "Email already exists.";
        public static string PhoneExists = "Phone Number already exists.";
        public static string AddUser = "Your account register successfully. We've send credential to your mail.";
        public static string ProfileImage = "Profile image successfullly upload.";

        // Messages for Role Management
        public static string RoleCreated = "The role has been created successfully.";
        public static string RoleUpdated = "The role has been updated successfully.";
        public static string RoleDeleted = "The role has been deleted successfully.";
        public static string RoleNotFound = "The specified role could not be found.";
        public static string RoleAlreadyExists = "A role with this name already exists.";

        // Messages for Assigning Roles to Users
        public static string AssignRoleToUserSuccess = "The role has been assigned to the user successfully.";
        public static string RemoveRoleFromUserSuccess = "The role has been removed from the user successfully.";
        public static string RoleNotAssigned = "The role could not be assigned to the user.";
        public static string RoleAlreadyAssigned = "The user already has this role assigned.";


        // General Error Messages
        public static string InvalidOperation = "The requested operation is invalid.";
        public static string UnauthorizedAccess = "You do not have permission to perform this action.";
        public static string OperationFailed = "The operation could not be completed. Please try again.";
        public static string OperationSuccess = "The operation was completed successfully.";

        
        //user
        public static string ActiveUser = "User active successfully.";
        public static string InActiveUser = "User Inactive successfully.";

        public static string Notificationupdate = "Notification update successfully";
        public static string NotFoundNotification = "No notification found to update.";
        public static string ClearAll = "All notifications have been cleared.";
        public static string NotFoundClear = "No notifications found to clear.";
        public static string sendnotification = "Send notification successfully.";
        public static string TraderNotExists = "Invalid UserId. Notification not sent to these traders.";

        
    }
}
