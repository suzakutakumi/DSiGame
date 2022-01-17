package action

import (
	"net/http"

	"github.com/gin-gonic/gin"
)

type detailOfAction struct {
	FromId    int `json:"fromId"`
	ToId      int `json:"toId"`
	NewId     int `json:"newId"`
	X         int `json:"x"`
	Z         int `json:"z"`
	MoveCount int `json:"moveCount"`
}

type _Action struct {
	Number     int            `form:"number" json:"number"`
	PlayerId   int            `json:"playerId"`
	WhatAction interface{}    `json:"whatAction"`
	Action     detailOfAction `json:"action"`
}

var action map[int]*_Action = map[int]*_Action{0: {0, 0, nil, detailOfAction{0, 0, 0, 0, 0, 0}}}

func NewRoom(num int) {
	action[num] = &_Action{0, 0, nil, detailOfAction{0, 0, 0, 0, 0, 0}}
}

func DeleteRoom(num int) {
	delete(action, num)
}

func PostAction(ctx *gin.Context) {
	var num _Action
	ctx.BindJSON(&num)
	action[num.Number] = &num
	ctx.Status(http.StatusOK)
}

func GetAction(ctx *gin.Context) {
	var num _Action
	ctx.BindQuery(&num)
	ctx.JSON(http.StatusOK, action[num.Number])
}
