#pragma checksum "..\..\VytvorHlaskuWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "20079829219CC1042E8C64A90A960EDC0EEE92E6AD4D8A95DE5194C505EBA972"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

using ChválicíAppka;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ChválicíAppka {
    
    
    /// <summary>
    /// VytvorHlaskuWindow
    /// </summary>
    public partial class VytvorHlaskuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\VytvorHlaskuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ChválicíAppka.VytvorHlaskuWindow vytvorHlaskuWindow;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\VytvorHlaskuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label VytvoreniHlaskyHlaskaLabel;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\VytvorHlaskuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox vytvoreniHlaskyHlaskaTextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\VytvorHlaskuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton vytvorHlaskuPochavalaRadio;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\VytvorHlaskuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton vytvorHlaskuurazkaRadio;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\VytvorHlaskuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button vytvorHlaskuPridatButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\VytvorHlaskuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button vytvorHlaskuStornoButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ChválicíAppka;component/vytvorhlaskuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VytvorHlaskuWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.vytvorHlaskuWindow = ((ChválicíAppka.VytvorHlaskuWindow)(target));
            return;
            case 2:
            this.VytvoreniHlaskyHlaskaLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.vytvoreniHlaskyHlaskaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.vytvorHlaskuPochavalaRadio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.vytvorHlaskuurazkaRadio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.vytvorHlaskuPridatButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\VytvorHlaskuWindow.xaml"
            this.vytvorHlaskuPridatButton.Click += new System.Windows.RoutedEventHandler(this.vytvorHlaskuPridatButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.vytvorHlaskuStornoButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\VytvorHlaskuWindow.xaml"
            this.vytvorHlaskuStornoButton.Click += new System.Windows.RoutedEventHandler(this.vytvorHlaskuStornoButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

