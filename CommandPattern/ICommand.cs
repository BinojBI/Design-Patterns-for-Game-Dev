using UnityEngine;

namespace CoommandPattern { 
public interface ICommand
{
        void Execute();
        void Undo();
    }

}
