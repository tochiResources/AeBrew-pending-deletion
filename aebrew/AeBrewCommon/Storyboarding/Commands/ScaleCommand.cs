﻿using AeBrewCommon.Storyboarding.CommandValues;

namespace AeBrewCommon.Storyboarding.Commands
{
    public class ScaleCommand : Command<CommandDecimal>
    {
        public ScaleCommand(OsbEasing easing, double startTime, double endTime, CommandDecimal startValue, CommandDecimal endValue)
            : base("S", easing, startTime, endTime, startValue, endValue)
        {
        }

        public override CommandDecimal ValueAtProgress(double progress)
            => StartValue + (EndValue - StartValue) * progress;

        public override CommandDecimal Midpoint(Command<CommandDecimal> endCommand, double progress)
            => StartValue + (endCommand.EndValue - StartValue) * progress;

        public override IFragmentableCommand GetFragment(double startTime, double endTime)
        {
            if (IsFragmentable)
            {
                var startValue = ValueAtTime(startTime);
                var endValue = ValueAtTime(endTime);
                return new ScaleCommand(Easing, startTime, endTime, startValue, endValue);
            }
            return this;
        }
    }
}