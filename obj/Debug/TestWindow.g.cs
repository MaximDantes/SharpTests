#pragma checksum "..\..\TestWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B4681424F0F5FF60113B80F37324CAB02307358266ABDF71ED7B31F656DB11A8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SharpTests;
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


namespace SharpTests {
    
    
    /// <summary>
    /// TestWindow
    /// </summary>
    public partial class TestWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\TestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titleTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\TestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox levelComboBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\TestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid questionsGrid;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\TestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addQuestionButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\TestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteTestButton;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\TestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button testButton;
        
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
            System.Uri resourceLocater = new System.Uri("/SharpTests;component/testwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TestWindow.xaml"
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
            this.titleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.levelComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.questionsGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 41 "..\..\TestWindow.xaml"
            this.questionsGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.questionsGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.addQuestionButton = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\TestWindow.xaml"
            this.addQuestionButton.Click += new System.Windows.RoutedEventHandler(this.addQuestionButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.deleteTestButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\TestWindow.xaml"
            this.deleteTestButton.Click += new System.Windows.RoutedEventHandler(this.deleteTestButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.testButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

