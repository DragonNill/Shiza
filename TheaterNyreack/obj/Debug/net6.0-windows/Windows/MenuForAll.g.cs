﻿#pragma checksum "..\..\..\..\Windows\MenuForAll.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F9256FD5E4C5B2EFF4B1655B6B0EF78DEBF8D9E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using TheaterNyreack.Windows;


namespace TheaterNyreack.Windows {
    
    
    /// <summary>
    /// MenuForAll
    /// </summary>
    public partial class MenuForAll : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\Windows\MenuForAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button showListShowsButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Windows\MenuForAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button profileAndAddNewActorButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Windows\MenuForAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button showListContractsButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\MenuForAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TheaterNyreack;component/windows/menuforall.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\MenuForAll.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\Windows\MenuForAll.xaml"
            ((TheaterNyreack.Windows.MenuForAll)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.showListShowsButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Windows\MenuForAll.xaml"
            this.showListShowsButton.Click += new System.Windows.RoutedEventHandler(this.showListShowsButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.profileAndAddNewActorButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Windows\MenuForAll.xaml"
            this.profileAndAddNewActorButton.Click += new System.Windows.RoutedEventHandler(this.profileAndAddNewActorButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.showListContractsButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Windows\MenuForAll.xaml"
            this.showListContractsButton.Click += new System.Windows.RoutedEventHandler(this.showListContractsButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Windows\MenuForAll.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

