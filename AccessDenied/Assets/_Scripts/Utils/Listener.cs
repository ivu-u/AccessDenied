/// This util script is imported from a previous game that I've made in Java.
/// @author  Ryan Vo
/// @version 1.0
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class is used as a way to encapsulate functions in order to use them as variables for function parameters, etc.
/// </summary>
/// <remarks>
/// It would encapsulate a function and attach itself to an outside list that contains all connected functions.
/// Since <c>_FuncList</c> contains all the connected functions, it's easy to just call them or disconnect them. A direct reference is not even needed.
/// <para>
/// IMPORTANT: One important caveat to this is that the function interface MUST return a bool, as this is used to detect when a function should be garbage collected.
/// For example if it returns true, then the function is able to run again. If it returns false, the function is removed from its parent list (funcList) and would not run again.
/// Basically, function return true = good, function return false = bad and destroyed/disconnected immediately.
/// </para>
/// </remarks>
public class Listener<T> : DisposableEvent {
	/// <summary>Private property that stores the actual function.</summary>
	private Func<T, bool> _Func;

	/// <summary>Private reference to List that stores this object.</summary>
	private List<Listener<T>> _Parent;

	private List<Listener<T>> _InternalFunc;

	/// <summary>
	/// Initialize Listener.
	/// </summary>
	/// <param name="Func"> Lambda function to wrap. </param>
	/// <param name="ParentList"> Reference to List that this function appends to. </param>
	/// <param name="PlayOnce"> Defines if the function will be destroyed right after calling. </param>
	public Listener(Func<T, bool> Func, List<Listener<T>> ParentList, bool PlayOnce) {
		this._Func = Func;
		this._PlayOnce = PlayOnce; //If PlayOnce is true, this function only runs once, and then it disconnects itself from the variable
		this._Parent = ParentList;
		ParentList.Add(this); //How this works is that this class appends itself to an array that belongs to another class. Whenever that class wants to, it goes through this array and run every function attached.
	}
	public Listener(Func<T, bool> Func, List<Listener<T>> ParentList) {
		this._Func = Func;
		this._Parent = ParentList;
		ParentList?.Add(this); //How this works is that this class appends itself to an array that belongs to another class. Whenever that class wants to, it goes through this array and run every function attached.
	}

	public Listener(Func<T, bool> Func) {
		this._Func = Func;
	}

	/// <summary>
	/// Calls function. Was to lazy to find a way to actually make this use () like a function.
	/// </summary>
	/// <param name="v"> Value to send to wrapped function. </param>
	/// <returns>A boolean defining if it should be run again. </returns>
	public bool Call(T v) {
		if (!this._Destroyed) {
			if (!this._Func(v)) {
				this._Destroyed = true;
			}
			return !this._Destroyed;
		}
		return false;
	}
}