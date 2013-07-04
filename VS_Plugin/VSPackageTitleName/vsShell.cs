#region Assembly Microsoft.VisualStudio.Shell.11.0.dll, v11.0.0.0
// C:\Program Files (x86)\Microsoft Visual Studio 11.0\VSSDK\VisualStudioIntegration\Common\Assemblies\v4.0\Microsoft.VisualStudio.Shell.11.0.dll
#endregion

using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using System;
using System.ComponentModel.Design;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Microsoft.VisualStudio.Shell
{
    // Summary:
    //     Provides a managed implementation of the interfaces required to create a
    //     fully functional VSPackage.
    [ComVisible(true)]
    [PackageRegistration]
    public abstract class Package : IVsPackage, IServiceProvider, IOleCommandTarget, IVsPersistSolutionOpts, IServiceContainer, System.IServiceProvider, IVsUserSettings, IVsUserSettingsMigration, IVsUserSettingsQuery, IVsToolWindowFactory, IVsToolboxItemProvider
    {
        // Summary:
        //     Initializes a new instance of Microsoft.VisualStudio.Shell.Package.
        protected Package();

        // Summary:
        //     Gets the root registry key of the current Visual Studio registry hive.
        //
        // Returns:
        //     The root Microsoft.Win32.RegistryKey of the Visual Studio registry hive.
        public RegistryKey ApplicationRegistryRoot { get; }
        //
        // Summary:
        //     Gets the path to user data storage for Visual Studio.
        //
        // Returns:
        //     The path to user data storage.
        public string UserDataPath { get; }
        //
        // Summary:
        //     Gets the path to local user data storage for Visual Studio.
        //
        // Returns:
        //     The path to local user data storage.
        public string UserLocalDataPath { get; }
        //
        // Summary:
        //     Gets a registry key that can be used to store user data.
        //
        // Returns:
        //     A Microsoft.Win32.RegistryKey that can be used to store user data.
        public RegistryKey UserRegistryRoot { get; }
        //
        // Summary:
        //     Gets a value indicating whether the package in the process of shutdown.
        //
        // Returns:
        //     true if the package is in the process of shutdown, otherwise false.
        public bool Zombied { get; }

        // Summary:
        //     Event generated whenever Visual Studio initializes its Toolbox.
        protected event EventHandler ToolboxInitialized;
        //
        // Summary:
        //     Event generated whenever Visual Studio upgrades its Toolbox.
        protected event EventHandler ToolboxUpgraded;

        // Summary:
        //     Adds a user option key name into the list of option keys.
        //
        // Parameters:
        //   name:
        //     The name of the option key to add. An option key name must not have any periods
        //     in it.
        protected void AddOptionKey(string name);
        //
        // Summary:
        //     Creates the specified COM object using the Visual Studio's local registry
        //     CLSID object.
        //
        // Parameters:
        //   clsid:
        //     The CLSID of the object to create.
        //
        //   iid:
        //     The interface IID the object implements.
        //
        //   type:
        //     The managed type of the object to return.
        //
        // Returns:
        //     An instance of the created object.
        public object CreateInstance(ref Guid clsid, ref Guid iid, Type type);
        //
        // Summary:
        //     Enables derived classes to provide an implementation if necessary.
        //
        // Parameters:
        //   persistenceSlot:
        //     The GUID of the tool window that should be created.
        //
        // Returns:
        //     Microsoft.VisualStudio.VSConstants.S_OK if successful, otherwise an error
        //     code.
        public int CreateTool(ref Guid persistenceSlot);
        //
        // Summary:
        //     Creates a tool window of the specified type with the specified ID.
        //
        // Parameters:
        //   toolWindowType:
        //     The type of tool window to create.
        //
        //   id:
        //     The tool window ID. This is 0 for a single-instance tool window.
        //
        // Returns:
        //     An instance of the requested tool window.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     toolWindowType is null.
        //
        //   System.ArgumentException:
        //     id is less than 0.toolWindowType is not derived from Microsoft.VisualStudio.Shell.ToolWindowPane
        //     type.
        protected WindowPane CreateToolWindow(Type toolWindowType, int id);
        //
        // Summary:
        //     Releases the resources used by the Microsoft.VisualStudio.Shell.Package object.
        //
        // Parameters:
        //   disposing:
        //     true if the object is being disposed, false if it is being finalized.
        protected virtual void Dispose(bool disposing);
        //
        // Summary:
        //     Gets the tool window corresponding to the specified type and ID.
        //
        // Parameters:
        //   toolWindowType:
        //     The type of tool window to create.
        //
        //   id:
        //     The tool window ID. This is 0 for a single-instance tool window.
        //
        //   create:
        //     If true, the tool window is created if it does not exist.
        //
        // Returns:
        //     An instance of the requested tool window. If create is false and the tool
        //     window does not exist, null is returned.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     toolWindowType is null.
        //
        //   System.ArgumentException:
        //     toolWindowType is not derived from Microsoft.VisualStudio.Shell.ToolWindowPane.toolWindowType
        //     does not have a public constructor .
        public ToolWindowPane FindToolWindow(Type toolWindowType, int id, bool create);
        //
        // Summary:
        //     Gets the window pane corresponding to the specified type and ID, and if no
        //     window pane of that type exists creates one if told to do so.
        //
        // Parameters:
        //   toolWindowType:
        //     The type of the window to be created.
        //
        //   id:
        //     The instance ID.
        //
        //   create:
        //     true to create a window pane if none exists, otherwise false.
        //
        // Returns:
        //     The Microsoft.VisualStudio.Shell.WindowPane.
        public WindowPane FindWindowPane(Type toolWindowType, int id, bool create);
        //
        // Summary:
        //     Gets the automation object for the VSPackage.
        //
        // Parameters:
        //   name:
        //     The name of the automation object to return. If name is null, GetAutomationObject
        //     returns the default automation object for the VSPackage.
        //
        // Returns:
        //     An instance of the automation object, or null if no automation support is
        //     available.
        //
        // Exceptions:
        //   System.NotImplementedException:
        //     Thrown by the base implementation of GetAutomationObject.
        protected virtual object GetAutomationObject(string name);
        //
        // Summary:
        //     Gets the requested dialog page.
        //
        // Parameters:
        //   dialogPageType:
        //     The type of dialog page to retrieve.
        //
        // Returns:
        //     An instance of the requested page.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     dialogPageType is null.
        //
        //   System.ArgumentException:
        //     dialogPageType is not derived from Microsoft.VisualStudio.Shell.DialogPage.dialogPageType
        //     does not have a public constructor.
        protected DialogPage GetDialogPage(Type dialogPageType);
        //
        // Summary:
        //     Gets a service proffered globally by Visual Studio or one of its packages. This
        //     is the same as calling GetService() on an instance of a package that proffers
        //     no services itself.
        //
        // Parameters:
        //   serviceType:
        //     The type of the service requested.
        //
        // Returns:
        //     The service being requested if available, otherwise null.
        public static object GetGlobalService(Type serviceType);
        //
        // Summary:
        //     Gets the requested output window.
        //
        // Parameters:
        //   page:
        //     The GUID corresponding to the pane. (See Microsoft.VisualStudio.VSConstants
        //     class for the GUIDs which correspond to output panes.)
        //
        //   caption:
        //     The caption to create if the pane does not exist.
        //
        // Returns:
        //     The Microsoft.VisualStudio.Shell.Interop.IVsOutputWindowPane interface. Returns
        //     null in case of failure.
        public IVsOutputWindowPane GetOutputPane(Guid page, string caption);
        //
        // Summary:
        //     Returns the locale associated with this service provider.
        //
        // Returns:
        //     Returns the locale identifier for the service provider.
        public int GetProviderLocale();
        //
        // Summary:
        //     Gets type-based services from the VSPackage service container.
        //
        // Parameters:
        //   serviceType:
        //     The type of service to retrieve.
        //
        // Returns:
        //     An instance of the requested service, or null if the service could not be
        //     found.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     serviceType is null.
        protected object GetService(Type serviceType);
        //
        // Summary:
        //     Gets the content of the data format for the specified toolbox item ID and
        //     data format.
        //
        // Parameters:
        //   itemId:
        //     The item ID.
        //
        //   format:
        //     The data format.
        //
        // Returns:
        //     The content of the data format.
        protected virtual object GetToolboxItemData(string itemId, DataFormats.Format format);
        //
        // Summary:
        //     Called when the VSPackage is loaded by Visual Studio.
        protected virtual void Initialize();
        //
        // Summary:
        //     Invoked by the package class when there are options to be read out of the
        //     solution file.
        //
        // Parameters:
        //   key:
        //     The name of the option key to load.
        //
        //   stream:
        //     The stream to load the option data from.
        protected virtual void OnLoadOptions(string key, Stream stream);
        //
        // Summary:
        //     Invoked by the Microsoft.VisualStudio.Shell.Package class when there are
        //     options to be saved to the solution file.
        //
        // Parameters:
        //   key:
        //     The name of the option key to save.
        //
        //   stream:
        //     The stream to save the option data to.
        protected virtual void OnSaveOptions(string key, Stream stream);
        //
        // Summary:
        //     Parses an embedded text resource of appropriate format for information about
        //     which items should be added to the Toolbox.
        //
        // Parameters:
        //   resourceData:
        //     A text reader that provides toolbox item data in the format described in
        //     Remarks.
        //
        //   packageGuid:
        //     The GUID of the VSPackage.
        protected void ParseToolboxResource(TextReader resourceData, Guid packageGuid);
        //
        // Summary:
        //     Parses an embedded text resource of appropriate format for information about
        //     which items should be added to the Toolbox.
        //
        // Parameters:
        //   resourceData:
        //     A text reader that provides toolbox item data in the format described in
        //     Remarks.
        //
        //   localizedCategories:
        //     A resource manager that provides localized lookup names for the categories
        //     provided in the resource data. This parameter can be null, in which case
        //     the category names are directly used.
        protected void ParseToolboxResource(TextReader resourceData, ResourceManager localizedCategories);
        //
        // Summary:
        //     Called to ask the package if the shell can be closed.
        //
        // Parameters:
        //   canClose:
        //     [out] Returns true if the shell can be closed, otherwise false.
        //
        // Returns:
        //     Microsoft.VisualStudio.VSConstants.S_OK if the method succeeded, otherwise
        //     an error code.
        protected virtual int QueryClose(out bool canClose);
        //
        // Summary:
        //     Registers an editor factory with Visual Studio.
        //
        // Parameters:
        //   factory:
        //     The editor factory to register.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     factory is null.
        protected void RegisterEditorFactory(IVsEditorFactory factory);
        //
        // Summary:
        //     Registers a project factory with Visual Studio.
        //
        // Parameters:
        //   factory:
        //     The project factory to register.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     factory is null.
        protected void RegisterProjectFactory(IVsProjectFactory factory);
        //
        // Summary:
        //     Displays a specified tools options page.
        //
        // Parameters:
        //   optionsPageType:
        //     The options page to open. The options page is identified by the GUID of the
        //     optionsPageType object passed in.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     optionsPageType is null.
        public void ShowOptionPage(Type optionsPageType);
    }
}
