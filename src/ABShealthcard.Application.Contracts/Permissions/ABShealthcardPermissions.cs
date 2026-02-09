namespace ABShealthcard.Permissions;

public static class ABShealthcardPermissions
{
    public const string GroupName = "ABShealthcard";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Patient
    {
        public const string Default = GroupName + ".Patient";
        public const string ProfileView = Default + ".Profile.View";
        public const string ProfileEdit = Default + ".Profile.Edit";
        public const string HistoryManage = Default + ".History.Manage";
        public const string MedicationsManage = Default + ".Medications.Manage";
    }
}
