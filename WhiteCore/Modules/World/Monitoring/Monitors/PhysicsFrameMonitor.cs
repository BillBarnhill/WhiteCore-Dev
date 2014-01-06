/*
 * Copyright (c) Contributors, http://WhiteCore-sim.org/, http://opensimulator.org/
 * See CONTRIBUTORS.TXT for a full list of copyright holders.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the WhiteCore-Sim Project nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using WhiteCore.Framework;
using WhiteCore.Framework.Modules;
using WhiteCore.Framework.SceneInfo;

namespace WhiteCore.Modules.Monitoring.Monitors
{
    public class PhysicsFrameMonitor : IPhysicsFrameMonitor
    {
        private float physicsFPS;

        public PhysicsFrameMonitor(IScene scene)
        {
        }

        #region Implementation of IMonitor

        public double GetValue()
        {
            return LastReportedPhysicsFPS;
        }

        public string GetName()
        {
            return "Total Physics Frame Time";
        }

        public string GetInterfaceName()
        {
            return "IPhysicsFrameMonitor";
        }

        public string GetFriendlyValue()
        {
            return (int) GetValue() + "ms";
        }

        #endregion

        #region Other Methods

        #region IMonitor Members

        public void ResetStats()
        {
            physicsFPS = 0;
        }

        #endregion

        #region IPhysicsFrameMonitor Members

        public void AddFPS(int value)
        {
            physicsFPS += value;
        }

        #endregion

        #endregion

        #region IPhysicsFrameMonitor Members

        public float LastReportedPhysicsFPS { get; set; }

        public float PhysicsFPS
        {
            get { return physicsFPS; }
        }

        #endregion
    }
}