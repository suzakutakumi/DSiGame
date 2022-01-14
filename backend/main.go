package main

import (
	"backend/move"

	"github.com/gin-gonic/gin"
)

func main() {
	r := gin.Default()
	r.POST("/moveGroup", move.PostMoveGroup)
	r.GET("/moveGroup", move.GetMoveGroup)
	r.Run()
}
