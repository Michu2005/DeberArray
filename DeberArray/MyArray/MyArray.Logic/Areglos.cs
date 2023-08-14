using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArray.Logic
{
    public class Areglos
    {
        private int[] _array;
        private int _top;

        public Areglos(int n)
        {
            _array = new int[n]; //n posiciones
            _top = 0; //tope ser cero
            N = n; // mi parte fisica
        }

        public int N { get; } // Lectura

        public bool IsFull => _top == N; // Arreglo lleno
        public bool IsEmpty => _top == 0; // Arreglo vacio

        public void Fill(int minimo, int maximo)
        {
            Random random = new Random();
            
            for (int contador = 0; contador < N; contador++)
            {
                _array[contador] = random.Next(minimo, maximo);
            }
            _top = N;
        }

        public Areglos NotRepeat()
        {
            int countNoRepat = 0;
            for (int i = 0; i < _top; i++)
            {
                if (!esRepetido(i))
                {
                    countNoRepat++;
                }
            }

            var noRepeat = new Areglos(countNoRepat);

            for (int i = 0; i < _top; i++)
            {
                if (!esRepetido(i))
                {
                    noRepeat.Add(_array[i]);
                }

            }

            return noRepeat;
        }

        public Areglos Repeated()
        {
            int countRepated = 0;
            for (int i = 0; i < _top; i++)
            {
                if (esRepetido(i))
                {
                    countRepated++;
                }
            }

            var Repeat = new Areglos(countRepated);

            for (int i = 0; i < _top; i++)
            {
                if (esRepetido(i))
                {
                    Repeat.Add(_array[i]);
                }
            }

            return Repeat;
        }

        private bool esRepetido(int i)
        {            
            bool isRepeat = false;
            for (int j = 0; j < _top; j++)
            {
                if (i != j && _array[i] == _array[j])
                {
                    isRepeat = true;
                    break;
                }
            }
            return isRepeat;
        }

        public Areglos Primo()
        {
            int countPrimos = 0;
            for (int i = 0; i < _top; i++)
            {
                if (IsPrimo(_array[i]))
                {
                    countPrimos++;
                }
            }

            var getIsPrimos  = new Areglos(countPrimos);

            for (int i = 0; i < _top; i++)
            {
                if (IsPrimo(_array[i]))
                {
                    getIsPrimos.Add(_array[i]);
                }
            }
            return getIsPrimos;
        }

        public Areglos Pares()
        {
            int countPares = 0;
            for (int i = 0; i < _top; i++)
            {
                if (_array[i] % 2 == 0)
                {
                    countPares++;
                }
            }
            var getPares = new Areglos(countPares);

            for (int i = 0; i < _top; i++)
            {
                if (_array[i] % 2 == 0)
                {
                    getPares.Add(_array[i]);
                }
            }

            return getPares;
        }

        // sort(true) => ordene acendente
        public void Sort()
        {
            Sort(false);
        }

        public int[] Get_array()
        {
            return _array;
        }

        public void Add(int n)
        {
            if (IsFull)
            {
                throw new Exception("Este arreglo esta lleno");
            }
            _array[_top] = n;
            _top++;
        }

        public void Insertar(int position, int number)
        {
            if (IsFull)
            {
                throw new Exception("Este arreglo esta lleno");
            }

            if (position < 0) position = 0;
            if (position > _top) position = _top;

            for (int i = _top; i > position; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[position] = number;
            _top++;
        }

        public void Sort(bool desc)
        {
            for (int i=0; i < _top - 1; i++)
            {
                for (int j = i + 1; j < _top; j++)
                {
                    var comparador = desc ? _array[i] < _array[j] : _array[i] > _array[j];
                    if(comparador)  
                    {
                        Change(ref _array[i], ref _array[j]);
                    }
                }
            }
        }

        public override string ToString()
        {
            string output = string.Empty;
            int count = 0;
            for (int i = 0; i < _top; i++)
            {
                if (count > 9)
                {
                    output += "\n";
                    count = 0;
                }
                output += $"{_array[i]}\t";
                count++;
            }
            return output;
        }

        private void Change(ref int a, ref int b)
        {
            var aux = a;
            a = b;
            b = aux;
        }

        private bool IsPrimo(int n)
        {
            if (n <= 1)
                return false;

            // Check from 2 to sqrt(n)
            for (int i = 2; i < Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}

