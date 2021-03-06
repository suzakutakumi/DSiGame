package move

import (
	"net/http"

	"github.com/gin-gonic/gin"
)

type _Move struct {
	Number   int  `json:"number" form:"number"`
	PlayerId int  `json:"playerId"`
	IsMove   bool `json:"isMove"`
	GroupId  int  `json:"groupId"`
	X        int  `json:"x"`
	Y        int  `json:"y"`
}

var move map[int]*_Move = map[int]*_Move{0: &_Move{0, 0, false, 0, 0, 0}}

func NewRoom(num int) {
	move[num] = &_Move{0, 0, false, 0, 0, 0}
}

func DeleteRoom(num int) {
	delete(move, num)
}

func PostMoveGroup(ctx *gin.Context) {
	var num _Move
	ctx.BindJSON(&num)
	move[num.Number] = &num
	move[num.Number].IsMove = true
	ctx.Status(http.StatusOK)
}

func GetMoveGroup(ctx *gin.Context) {
	var num _Move
	ctx.BindQuery(&num)
	ctx.JSON(http.StatusOK, move[num.Number])
	move[num.Number].IsMove = false
}
