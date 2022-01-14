package main

import (
	"backend/action"
	"backend/move"

	"github.com/gin-gonic/gin"
)

func main() {
	r := gin.Default()
	r.POST("/moveGroup", move.PostMoveGroup)
	r.GET("/moveGroup", move.GetMoveGroup)
	r.POST("/action", action.PostAction)
	r.GET("/action", action.GetAction)
	r.Run()
}
