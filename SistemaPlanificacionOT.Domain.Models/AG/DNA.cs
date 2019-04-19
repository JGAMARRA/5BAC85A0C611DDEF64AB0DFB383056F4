using SistemaPlanificacionOT.Domain.Models;
using System;

public class DNA<T>
{
	public T[] Genes { get; private set; }
	public float Fitness { get; private set; }

	private Random random;
	//private Func<T> getRandomGene;
	private Func<Cotizacion> fitnessFunction;
   // private  Random _random = new Random();

    /// <summary>
    /// Shuffle the array.
    /// </summary>
    /// <typeparam name="T">Array element type.</typeparam>
    /// <param name="array">Array to shuffle.</param>
    private void Shuffle<T>(T[] array, Random _random)
    {
        //Random _random = new Random();
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            // Use Next on random instance with an argument.
            // ... The argument is an exclusive bound.
            //     So we will not go past the end of the array.
            int r = i + _random.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
    public DNA(T[] arreglo,int size, Random random, Func<Cotizacion> fitnessFunction, bool shouldInitGenes = true)
	{
		Genes = new T[size];
		this.random = random;
		//this.getRandomGene = getRandomGene;
		this.fitnessFunction = fitnessFunction;

		if (shouldInitGenes)
		{
            
            Shuffle(arreglo, random);

            arreglo.CopyTo(Genes, 0);
            
            //for (int i = 0; i < Genes.Length; i++)
            //{
            //    Genes[i] = getRandomGene();

            //}
            //Array.Sort(Genes);

        }
	}

	//public float CalculateFitness(Cotizacion oCotizacion)
	//{
	//	Fitness = fitnessFunction;
	//	return Fitness;
	//}

	public DNA<T> Crossover(DNA<T> otherParent)
	{
		DNA<T> child = new DNA<T>(Genes,Genes.Length, random, fitnessFunction, shouldInitGenes: false);

		for (int i = 0; i < Genes.Length; i++)
		{
			child.Genes[i] = random.NextDouble() < 0.5 ? Genes[i] : otherParent.Genes[i];
		}

		return child;
	}

	public void Mutate(float mutationRate)
	{
        T temp;
        for (int i = 0; i < Genes.Length; i++)
        {
            if (random.NextDouble() < mutationRate)
            {
                temp=Genes[i];
                if (i == 0)
                {
                    Genes[i] = Genes[2];
                    Genes[2] = temp;
                }
                else {
                    Genes[i] = Genes[i - 1];
                    Genes[i - 1] = temp;
                }

                
            }
        }
        //Shuffle(Genes);

        //Genes.CopyTo(Genes, 0);
    }
}