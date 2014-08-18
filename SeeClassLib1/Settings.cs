namespace csi.see.classlib1.Properties {
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings {
        //Default values
        //sqlConnect_master
        //sqlConnect_common
        //Integrated Security=True;Persist Security Info=False;Pooling=False;Data Source=.\SQLEXPRESS;Initial Catalog=master
        //Integrated Security=True;Persist Security Info=False;Pooling=False;Data Source=.\SQLEXPRESS;Initial Catalog=SeeCommon
        public Settings() {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            //this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
            //this.SettingsLoaded += new System.Configuration.SettingsLoadedEventHandler(Settings_SettingsLoaded);
        }

        void Settings_SettingsLoaded(object sender, System.Configuration.SettingsLoadedEventArgs e)
        {
                       
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) 
        {
            
            System.Diagnostics.Debug.WriteLine(e.NewValue.ToString());
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }
    }
}
