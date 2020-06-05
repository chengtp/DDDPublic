using DDD.Util.Extension;
using DDD.Util.Internal.MQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.Command
{
    /// <summary>
    /// command callback internal message command
    /// </summary>
    public class CommandCallbackInternalMessageCommand : IInternalMessageQueueCommand
    {

        List<Tuple<CommandCallbackOperation, CommandCallbackParameter>> operations = null;

        internal CommandCallbackInternalMessageCommand(List<Tuple<CommandCallbackOperation, CommandCallbackParameter>> operations)
        {
            this.operations = operations;
        }

        public void Run()
        {
            if (operations.IsNullOrEmpty())
            {
                return;
            }
            operations.ForEach(op =>
            {
                op.Item1(op.Item2);
            });
        }
    }
}
