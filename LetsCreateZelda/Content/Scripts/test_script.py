from LetsCreateZelda.Components import *
from LetsCreateZelda.Manager import *
from LetsCreateZelda.Gui import *


class Script(object): 

    def initialize(self): 
        self.counter = 0

    def run(self, game_time): 
        self.counter += game_time 
        if self.counter > 2000:
            self.counter = 0
            ManagerWindow.NewWindow('test', WindowMessage('Calling from script!'))

