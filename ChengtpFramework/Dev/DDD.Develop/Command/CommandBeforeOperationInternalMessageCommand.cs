using DDD.Util.Extension;
using DDD.Util.Internal.MQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.Command
{
    /// <summary>
    /// command before operation internal message command
    /// </summary>
    public class CommandBeforeOperationInternalMessageCommand : IInternalMessageQueueCommand
    {
        List<Tuple<CommandBeforeExecuteOperation, CommandBeforeExecuteParameter>> operations = null;

        internal CommandBeforeOperationInternalMessageCommand(List<Tuple<CommandBeforeExecuteOperation, CommandBeforeExecuteParameter>> operations)
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
