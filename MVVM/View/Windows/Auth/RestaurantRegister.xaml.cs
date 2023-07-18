﻿using FoodeLive.Auth;
using FoodeLive.MVVM.ViewModel;
using ScottPlot.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace FoodeLive.View.Windows.Auth
{
    /// <summary>
    /// Interaction logic for RestaurantRegister.xaml
    /// </summary>
    public partial class RestaurantRegister : Window
    {
        Brush Gray { get; set; }
        public RestaurantRegister()
        {
            InitializeComponent();
            Gray = password_length.Foreground;
        }

        ~RestaurantRegister() { }

        private void HandleSignUp_Click(object sender, RoutedEventArgs e)
        {
            string username = signup_username.Text;
            string password = signup_password.Password;
            Regex usernameRegex = new Regex("^[a-zA-Z0-9]+$");
            if (!usernameRegex.IsMatch(username))
            {
                System.Windows.MessageBox.Show("Tên người dùng không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if(string.IsNullOrEmpty(restaurantName.Text))
            {
                System.Windows.MessageBox.Show("Vui lòng nhập tên nhà hàng của bạn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (CheckSuccessValidate(password_case) && CheckSuccessValidate(password_length) && CheckSuccessValidate(password_match) && CheckSuccessValidate(password_specha))
            {
                if (AuthSignUp.CreateRestaurant(username, password, restaurantName.Text))
                {
                    System.Windows.MessageBox.Show("Tạo tài khoản cho nhà hàng thành công!");
                    Login login = new Login();
                    this.Close();
                    login.ShowDialog();
                }
            }
            else
                System.Windows.MessageBox.Show("Vui lòng điền phù hợp", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        bool CheckSuccessValidate(TextBlock tb)
        {
            return tb.Foreground == Brushes.ForestGreen;
        }

        void OnValidateSuccessful(ref SymbolIcon symbolIcon, ref TextBlock textBlock)
        {
            symbolIcon.Symbol = SymbolRegular.FoodGrains20;
            symbolIcon.Foreground = Brushes.ForestGreen;
            textBlock.Foreground = Brushes.ForestGreen;
            textBlock.FontWeight = FontWeights.SemiBold;
        }

        void OnValidateFail(ref SymbolIcon symbolIcon, ref TextBlock textBlock)
        {
            symbolIcon.Symbol = SymbolRegular.ErrorCircle12;
            symbolIcon.Foreground = Gray;
            textBlock.Foreground = Gray;
            textBlock.FontWeight = FontWeights.Regular;
        }


        private void signup_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = signup_password.Password;
            string confirmPassword = signup_confirm_password.Password;

            if (password.Length > 8)
                OnValidateSuccessful(ref password_length_icon, ref password_length);
            else
                OnValidateFail(ref password_length_icon, ref password_length);

            Regex lowerCase = new Regex(@"[A-Z][a-z]{0}");
            if (lowerCase.IsMatch(password))
                OnValidateSuccessful(ref password_case_icon, ref password_case);
            else
                OnValidateFail(ref password_case_icon, ref password_case);

            Regex specialCharaters = new Regex(@"[!@#$%^&*(),.?"":{}|<>]");
            if (specialCharaters.IsMatch(password))
                OnValidateSuccessful(ref password_specha_icon, ref password_specha);
            else
                OnValidateFail(ref password_specha_icon, ref password_specha);

            if (password.CompareTo(confirmPassword) == 0)
                OnValidateSuccessful(ref password_match_icon, ref password_match);
            else
                OnValidateFail(ref password_match_icon, ref password_match);
        }

        private void signup_confirm_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = signup_password.Password;
            string confirmPassword = signup_confirm_password.Password;

            if (confirmPassword.CompareTo(password) == 0)
                OnValidateSuccessful(ref password_match_icon, ref password_match);
            else
                OnValidateFail(ref password_match_icon, ref password_match);
        }

        private void SignUpToLogIn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.ShowDialog();
        }
    }
}
