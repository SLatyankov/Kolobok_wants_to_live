mergeInto(LibraryManager.library, {

  SaveData: function (data) {
      var dataString = UTF8ToString(data);
      var myobj = JSON.parse(dataString);
     player.setData(myobj);
  },

  LoadData: function () {
      player.getData().then(data => {
        const myJSON = JSON.stringify(data);
        MyGameInstance.SendMessage('DataBox', 'LoadFromServer', myJSON);
      });
  },  

  ShowAdv: function () {
    ysdk.adv.showFullscreenAdv({
      callbacks: {
          onClose: function(wasShown) {
            console.log("reward");
          },
          onError: function(error) {
            // some action on error
          }
      }
    })
  },

    GetDevice: function () {
      var device = ysdk.deviceInfo;
      MyGameInstance.SendMessage('DataBox', 'SetDevice', device.type);            
    }, 
      

});

