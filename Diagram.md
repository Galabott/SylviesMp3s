````plantuml
@startuml

class User{
    +id: int
    +email : string
    +password :string
    +User(int,string,string)
}
User *--> UserService
class UserService{
    +CurrentUser: User
    +GetInstance()
    +AddUser(string,string)
    +login(string,string)
}

class Music{
    +id: int
    +foilder_path: string
    +title: string
    +author: string
    +user_id: id
    +created_at: DateTime
    +updated_at: DateTime
}
Music *--> MusicService

class MusicService{
    +GetInstance()
    +AddMusic(int)
    +GetMusic(int)
    +DeleteMusic(int)
}
UserService -|> ControllerLogin
class ControllerLogin{
    +login()
}

UserService -|> ControllerApp
MusicService -|> ControllerApp
class ControllerApp{
    +Musics: List<Music>
}

Mp3Archive -|> ControllerApp
class Mp3Archive{
    +ReadMp3(string)
    +AddNewMp3(string)
    +AnalyseMp3(string)
    +DeleteMp3(string)
}




@enduml
````