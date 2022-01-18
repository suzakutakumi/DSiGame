package room

import (
	"math/rand"
	"net/http"
	"time"

	"backend/action"
	"backend/move"

	"github.com/gin-gonic/gin"
)

type _Start struct {
	IsStart bool `json:"isStart"`
}

type _Number struct {
	IsFirst bool `json:"isFirst"`
	Number  int  `json:"number" form:"number"`
}

type _RoomNumber struct {
	IsStart _Start
	Number  _Number
}

var roomNumbers map[int]*_RoomNumber = map[int]*_RoomNumber{}

func Init() {
	rand.Seed(time.Now().UnixNano())
}

func CreateRoom(ctx *gin.Context) {
	var num int
	numFlg := false
	for numFlg == false {
		num = rand.Intn(100)
		numFlg = true
		for key, _ := range roomNumbers {
			if key == num {
				numFlg = false
				break
			}
		}
	}
	move.NewRoom(num)
	action.NewRoom(num)
	roomNumbers[num] = &_RoomNumber{_Start{false}, _Number{rand.Intn(2) == 0, num}}
	ctx.JSON(http.StatusOK, roomNumbers[num].Number)
}

func EnterRoom(ctx *gin.Context) {
	var num _Number
	ctx.BindJSON(&num)

	numFlg := true
	for key, _ := range roomNumbers {
		if key == num.Number {
			numFlg = false
			break
		}
	}
	if numFlg {
		ctx.Status(http.StatusBadRequest)
		return
	}
	roomNumbers[num.Number].IsStart.IsStart = true
	roomNumbers[num.Number].Number.IsFirst = !roomNumbers[num.Number].Number.IsFirst
	ctx.JSON(http.StatusOK, roomNumbers[num.Number].Number)
}

func IsStart(ctx *gin.Context) {
	var num _Number
	ctx.BindQuery(&num)
	ctx.JSON(http.StatusOK, roomNumbers[num.Number].IsStart)
}

func DeleteRoom(ctx *gin.Context) {
	var num _Number
	ctx.BindQuery(&num)
	move.NewRoom(num.Number)
	action.NewRoom(num.Number)
	delete(roomNumbers, num.Number)
	ctx.Status(http.StatusOK)
}
