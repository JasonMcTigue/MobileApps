﻿#pragma checksum "C:\Users\JasonMcTigue\Documents\MobileApps\mobileApps\mobileApps\GameplayPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "826A9C373D1725912CFD29FF29C277A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace mobileApps {
    
    
    public partial class GameplayPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock txtScore;
        
        internal System.Windows.Controls.TextBlock txtTime;
        
        internal System.Windows.Controls.Canvas PlayingCanvas;
        
        internal System.Windows.Controls.TextBlock txtCountdown;
        
        internal System.Windows.Controls.HyperlinkButton hbtnTap;
        
        internal System.Windows.Controls.Grid resultsGrid;
        
        internal System.Windows.Controls.TextBlock txtResultTitle;
        
        internal System.Windows.Controls.TextBlock txtResultMessage;
        
        internal System.Windows.Controls.TextBlock txtResult;
        
        internal System.Windows.Controls.TextBlock txtScoreTotal;
        
        internal System.Windows.Controls.Button btnSkip;
        
        internal System.Windows.Controls.TextBlock textBlock;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/mobileApps;component/GameplayPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtScore = ((System.Windows.Controls.TextBlock)(this.FindName("txtScore")));
            this.txtTime = ((System.Windows.Controls.TextBlock)(this.FindName("txtTime")));
            this.PlayingCanvas = ((System.Windows.Controls.Canvas)(this.FindName("PlayingCanvas")));
            this.txtCountdown = ((System.Windows.Controls.TextBlock)(this.FindName("txtCountdown")));
            this.hbtnTap = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hbtnTap")));
            this.resultsGrid = ((System.Windows.Controls.Grid)(this.FindName("resultsGrid")));
            this.txtResultTitle = ((System.Windows.Controls.TextBlock)(this.FindName("txtResultTitle")));
            this.txtResultMessage = ((System.Windows.Controls.TextBlock)(this.FindName("txtResultMessage")));
            this.txtResult = ((System.Windows.Controls.TextBlock)(this.FindName("txtResult")));
            this.txtScoreTotal = ((System.Windows.Controls.TextBlock)(this.FindName("txtScoreTotal")));
            this.btnSkip = ((System.Windows.Controls.Button)(this.FindName("btnSkip")));
            this.textBlock = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
        }
    }
}

