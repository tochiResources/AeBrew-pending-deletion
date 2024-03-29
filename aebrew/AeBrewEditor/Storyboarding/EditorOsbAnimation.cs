﻿using OpenTK;
using AeBrewCommon.Storyboarding;
using BrewLib.Graphics;
using BrewLib.Graphics.Cameras;

namespace AeBrewEditor.Storyboarding
{
    public class EditorOsbAnimation : OsbAnimation, DisplayableObject, HasPostProcess
    {
        public void Draw(DrawContext drawContext, Camera camera, Box2 bounds, float opacity, Project project, FrameStats frameStats)
            => EditorOsbSprite.Draw(drawContext, camera, bounds, opacity, project, frameStats, this);

        public void PostProcess()
        {
            if (InGroup) 
                EndGroup();
        }
    }
}
