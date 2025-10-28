using UnityEngine;

namespace CoommandPattern
{
    public class MoveCommand : ICommand
    {
        private PlayerController player;
        private Vector3 direction;

        public MoveCommand(PlayerController player, Vector3 direction)
        {
            this.player = player;
            this.direction = direction;
        }

        public void Execute()
        {
            player.Move(direction);
        }

        public void Undo()
        {
            player.Move(-direction);
        }
    }

    public class JumpCommand : ICommand
    {
        private PlayerController player;

        public JumpCommand(PlayerController player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.Jump();
        }

        public void Undo() { /* optional */ }
    }

    public class AttackCommand : ICommand
    {
        private PlayerController player;

        public AttackCommand(PlayerController player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.Attack();
        }

        public void Undo() { /* optional */ }
    }
}
