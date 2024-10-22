Imports System.Reflection
Imports Microsoft.Extensions.DependencyInjection
Imports PluginSdk

Module Program

    <STAThread>
    Sub Main()

        '' Configura l'applicazione per utilizzare i controlli visivi moderni
        'Application.EnableVisualStyles()
        'Application.SetCompatibleTextRenderingDefault(False)

        '' Crea e avvia il form principale
        'Dim mainForm As New Form()
        'mainForm.Text = "Esempio con UserControl"
        'mainForm.Size = New Drawing.Size(400, 300)

        '' Crea un'istanza del tuo UserControl
        'Dim myControl As New MyUserControl()
        'myControl.Dock = DockStyle.Fill ' Adatta il controllo alle dimensioni del form

        '' Aggiungi l'UserControl al form
        'mainForm.Controls.Add(myControl)

        '' Avvia l'applicazione con il form principale
        'Application.Run(mainForm)


        ' Create a service collection for DI
        Dim serviceCollection As New ServiceCollection()

        ' Dynamically load the plugin assembly (replace with the actual path)
        Dim pluginAssembly As Assembly = Assembly.LoadFrom("C:\Users\daniele.totisco\source\repos\personal\plugin pattern winform poc\plugin one\bin\Debug\PluginOne.dll")

        ' Register all types that implement IPlugin from the loaded assembly
        Dim pluginType = pluginAssembly.GetTypes().FirstOrDefault(Function(t) GetType(IView).IsAssignableFrom(t) AndAlso t.IsClass AndAlso Not t.IsAbstract)

        ' Crea e avvia il form principale
        Dim mainForm As New Form()
        mainForm.Text = "Esempio con UserControl"
        mainForm.Size = New Drawing.Size(400, 300)

        ' Crea un'istanza del tuo UserControl
        Dim myControl = Activator.CreateInstance(pluginType)
        myControl.Dock = DockStyle.Fill ' Adatta il controllo alle dimensioni del form

        ' Aggiungi l'UserControl al form
        mainForm.Controls.Add(myControl)

        ' Avvia l'applicazione con il form principale
        Application.Run(mainForm)


        'For Each pluginType In pluginTypes
        '    serviceCollection.AddTransient(GetType(IPlugin), pluginType)
        'Next

        '' Build the DI container
        'Dim serviceProvider As IServiceProvider = serviceCollection.BuildServiceProvider()

        '' Resolve and execute the plugin(s)
        'Dim plugins As IEnumerable(Of IPlugin) = serviceProvider.GetServices(Of IPlugin)()
        'For Each plugin As IPlugin In plugins
        '    plugin.Execute() ' Execute the plugin
        'Next

        'Console.ReadLine() ' Keep console open to see the output
    End Sub

End Module
