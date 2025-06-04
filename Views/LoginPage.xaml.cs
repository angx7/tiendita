using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _411_tiendita.services;
using _411_tiendita.ViewModels;

namespace _411_tiendita.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(new AuthService(), this);
    }
}