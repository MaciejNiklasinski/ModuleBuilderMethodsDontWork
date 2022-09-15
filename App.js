import React from 'react';
import type {Node} from 'react';
import {Button, View, NativeModules } from 'react-native';

const { FancyMath, FancyMathNoAttr } = NativeModules;

const App: () => Node = () => {
  return (  
    <View style={{
      height: "100%",
      display: "flex",
      justifyContent: "space-around"
    }}>
      <Button
        title='FancyMath'
        onPress={(e) => {
          try {
            FancyMath.add(1.1, 1.1, (sum) => {
              alert(sum); 
            });
          } catch (error) {
            alert(error);
          }
        }} />
      <Button
        title='FancyMathNoAttr'
        onPress={(e) => {
          try {
            FancyMathNoAttr.add(1.1, 1.1, (sum) => {
              alert(sum); 
            });
          } catch (error) {
            alert(error);
          }
        }} />
    </View>
  );
};

export default App;
