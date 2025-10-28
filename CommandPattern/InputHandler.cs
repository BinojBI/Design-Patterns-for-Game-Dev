using System.Collections.Generic;
using UnityEngine;

namespace CoommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        public PlayerController player;
        private Stack<ICommand> commandHistory = new Stack<ICommand>();

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                ExecuteCommand(new MoveCommand(player, Vector3.forward));
            }

            if (Input.GetKey(KeyCode.S))
            {
                ExecuteCommand(new MoveCommand(player, Vector3.back));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExecuteCommand(new JumpCommand(player));
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                ExecuteCommand(new AttackCommand(player));
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                UndoLastCommand();
            }
        }

        void ExecuteCommand(ICommand command)
        {
            command.Execute();
            commandHistory.Push(command);
        }

        void UndoLastCommand()
        {
            if (commandHistory.Count > 0)
            {
                ICommand lastCommand = commandHistory.Pop();
                lastCommand.Undo();
            }
        }


    }
}
