using Avalonia.Controls;
using System.Collections.Generic;

namespace PruebadeAvalanoia;

public partial class VentanaClientes : Window
{
    public VentanaClientes()
    {
        InitializeComponent();
    }

    public VentanaClientes(List<Cliente> clientes) : this()
    {
        GridSecundario.ItemsSource = clientes;
    }
}