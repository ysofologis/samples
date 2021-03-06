﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.config {
    public class ConfigurationSetting {
        protected ConfigurationSetting( string name, string defaultValue) {
            this.Key = name;
            this.defaultValue = defaultValue;
        }
        public string Key {
            get; private set;
        }
        public string defaultValue {
            get;
            set;
        }
        public override string ToString( ) {
            return this.Key;
        }
        public override int GetHashCode( ) {
            return this.Key.GetHashCode();
        }
        public override bool Equals( object obj ) {
            if ( (obj is ConfigurationSetting) && (obj != null) ) {
                return this.Key.Equals(( obj as ConfigurationSetting ).Key);
            } else {
                return false;
            }
        }
    }
}
