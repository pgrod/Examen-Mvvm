using CommunityToolkit.Mvvm.ComponentModel;
using Examen_Mvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Examen_Mvvm.ViewModels
{
    public class Descuento : ObservableObject
    {
        private Producto _producto1 = new Producto();
        private Producto _producto2 = new Producto();
        private Producto _producto3 = new Producto();

        public Producto Producto1
        {
            get => _producto1;
            set
            {
                _producto1 = value;
                OnPropertyChanged();
                calcularDescuento();
            }
        }

        public Producto Producto2
        {
            get => _producto2;
            set
            {
                _producto2 = value;
                OnPropertyChanged();
                calcularDescuento();
            }
        }

        public Producto Producto3
        {
            get => _producto3;
            set
            {
                _producto3 = value;
                OnPropertyChanged();
                calcularDescuento();
            }
        }

        private decimal _subtotal;
        public decimal Subtotal
        {
            get => _subtotal;
            private set
            {
                _subtotal = value;
                OnPropertyChanged();
            }
        }

        private decimal _descuento;
        public decimal descuento
        {
            get => _descuento;
            private set
            {
                _descuento = value;
                OnPropertyChanged();
            }
        }

        private decimal _totalAPagar;
        public decimal TotalAPagar
        {
            get => _totalAPagar;
            private set
            {
                _totalAPagar = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalcularCommand { get; }
        public ICommand limpiarCommand { get; }

        public Descuento()
        {
            CalcularCommand = new Command(calcularDescuento);
            limpiarCommand = new Command(limpiarCampos);
        }

        private void calcularDescuento()
        {
            decimal total = Producto1.Precio + Producto2.Precio + Producto3.Precio;
            Subtotal = total;

            if (total >= 10000)
            {
                descuento = total * 0.3m;
            }
            else if (total >= 5000)
            {
                descuento = total * 0.2m;
            }
            else if (total >= 1000)
            {
                descuento = total * 0.1m;
            }
            else
            {
                descuento = 0;
            }

            TotalAPagar = total - descuento;
        }

        private void limpiarCampos()
        {
            Producto1.Precio = 0;
            Producto2.Precio = 0;
            Producto3.Precio = 0;
            Subtotal = 0;
            descuento = 0;
            TotalAPagar = 0;
        }
    }
}

