﻿using System.Windows;
using System.Windows.Controls;
using ExternalServiceInterfaces;

namespace ExternalServicesViewExtension
{
    /// <summary>
    /// Interaction logic for ExternalServiceMenuItem.xaml
    /// </summary>
    public partial class ExternalServiceMenuItem : UserControl
    {
        public ExternalServiceMenuItem()
        {
            InitializeComponent();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext == null) return;

            var service = DataContext as IExternalService<IOAuthAuthenticationData>;
            if (service == null) return;

            if (service.AuthenticationData == null)
            {
                var login = new LoginForm(service);
                login.Show();
            }
            else
            {
                service.Logout();
            }
        }
    }
}
