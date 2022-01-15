package action

import (
	"net/http"

	"github.com/gin-gonic/gin"
)

/*type _Attack struct {
	GroupId      int `json:groupId`
	EnemyGroupId int `json:enemyGroupId`
	MyAttack     int `json:myAttack`
	EnemyAttack  int `json:enemyAttack`
}

type _Change struct {
	FromId    int `json:fromId`
	ToId      int `json:toId`
	MoveCount int `json:moveCount`
}

type _Create struct {
	FromId    int `json:fromId`
	NewId     int `json:newId`
	X         int `json:x`
	Y         int `json:y`
	MoveCount int `json:moveCount`
}

type _Evolution struct {
	FromId    int `json:fromId`
	NewId     int `json:newId`
	X         int `json:x`
	Y         int `json:y`
	MoveCount int `json:moveCount`
}*/

type _Action struct {
	Number     int         `form:"number" json:number`
	PlayerId   int         `json:playerId`
	WhatAction interface{} `json:whatAction`
	Action     interface{} `json:action`
}

var action map[int]*_Action = map[int]*_Action{0: &_Action{0, 0, nil, nil}}

func NewRoom(num int) {
	action[num] = &_Action{0, 0, nil, nil}
}

func DeleteRoom(num int) {
	delete(action, num)
}

func PostAction(ctx *gin.Context) {
	var num _Action
	ctx.BindJSON(&num)
	action[num.Number] = &num
	/*switch action[num.Number].WhatAction {
	case "attack":
		var attack _Attack
		ctx.BindJSON(&attack)
		action[num.Number].Action = attack
	case "change":
		var change _Change
		ctx.BindJSON(&change)
		action[num.Number].Action = change
	case "create":
		var create _Create
		ctx.BindJSON(&create)
		action[num.Number].Action = create
	case "evolution":
		var evolution _Evolution
		ctx.BindJSON(&evolution)
		action[num.Number].Action = evolution
	}*/
	ctx.Status(http.StatusOK)
}

func GetAction(ctx *gin.Context) {
	var num _Action
	ctx.BindQuery(&num)
	ctx.JSON(http.StatusOK, action[num.Number])
}
