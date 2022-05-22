using UnityEngine;
using System.Collections;
using System;

public class IMyInterfaceTutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MyClass testing = new MyClass(); //Here, I have instantiated an instance
		//of the MyClass class based off the IMyInterface
		
		ClassDos secondclass = new ClassDos();
		TestingFunction(testing); //can use class as it uses IMyInterface
		TestingFunction(secondclass); // implementing another class instance using the same interface
	}
	
	
	void TestingFunction(IMyInterface myInterface)
	{
		myInterface.myFunction(); //This will actually carry out my function
	}
	
	
}

public interface IMyInterface{ //Good practice to start all interface identifies with an 'I'
	
	//event EventHandler OnMyEvent; // I can also define events 
	/* 
	I need to add a 'using System' if I want to use EventHandler
	*/
	
	//int numero {get; set;} //This is how I can define properties
	//Hoever, I cannot define fields in interfaces
	void myFunction(); // I don't define accesssors(public/private) as everything is public
}

public interface IInterfaceTwo{
	
	void FunctionTwo(int i);
}

//If I wanted to, I could make an interface inherit from aother interface
/*
public interface IInterfaceTwo : IMyInterface{
	
	void FunctionTwo(int i);
}
*/


public class MyClass : IMyInterface, IInterfaceTwo{
	// I can implement more than one interface, which is cool
	
	/*
	When using an interface, a class must use all public functions
	within that interface, otherwise it will not work and there will be errors
	*/
	public void myFunction()
	{
		Debug.LogWarning("Hooray. I have successfully created an interface");
	}
	
	public void FunctionTwo(int i)
	{
		
	}
}

public class ClassDos : IMyInterface{
	
	public void myFunction()
	{
		Debug.LogWarning("Hold up, there are two classes using the same interface now? That's mad, dog!");
	}
}
