using System;
namespace gamedevGame.interfaces
{
	public interface IIinputReader
	{
		Vector2 ReadInput();
		public bool IsDestinationInput { get; }
    }
}

