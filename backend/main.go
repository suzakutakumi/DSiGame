package main

import (
	"backend/action"
	"backend/move"
	"backend/room"

	"github.com/gin-gonic/gin"
)

func main() {
	room.Init()

	r := gin.Default()
	r.POST("/moveGroup", move.PostMoveGroup)
	r.GET("/moveGroup", move.GetMoveGroup)
	r.POST("/action", action.PostAction)
	r.GET("/action", action.GetAction)

	r.GET("/room/create", room.CreateRoom)
	r.POST("/room/enter", room.EnterRoom)
	r.GET("/room/isStart", room.IsStart)
	r.DELETE("/room", room.DeleteRoom)
	r.Run()
}
