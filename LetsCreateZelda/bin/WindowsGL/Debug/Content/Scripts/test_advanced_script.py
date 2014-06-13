from LetsCreateZelda.Components import *
from LetsCreateZelda.Manager import *
from LetsCreateZelda.Gui import *
from LetsCreateZelda import *


class Script(object): 

    def initialize(self): 
        self.counter = 0

    def run(self, game_time): 
        self.counter += game_time 
        sprite = owner.GetComponent[Sprite](ComponentType.Sprite)
        collision = owner.GetComponent[Collision](ComponentType.Collision)

        if collision.CheckCollisionWithEntities(sprite.Rectangle, True) and self.counter > 500:
            self.counter = 0
            ManagerWindow.NewWindow("test", WindowMessage("Advanced script running"))

