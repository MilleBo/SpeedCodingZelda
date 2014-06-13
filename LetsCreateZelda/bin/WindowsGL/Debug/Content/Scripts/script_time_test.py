from LetsCreateZelda.Components import *
from LetsCreateZelda.Manager import *
from LetsCreateZelda.Gui import *


class Script(object): 

    def initialize(self): 
        self.counter = 0

    def run(self, game_time): 
        self.counter += game_time 
        time_limit = 1000

        if self.counter > time_limit:
            self.counter = 0
            ManagerWindow.NewWindow('test', WindowMessage('Calling from script after ' + str(time_limit)))

