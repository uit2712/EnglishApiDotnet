#!/bin/bash
echo "" > $(docker inspect --format='{{.LogPath}}' db) && \
echo "" > $(docker inspect --format='{{.LogPath}}' adminer)
