#!/usr/bin/env python
import sys, math, os

def networkFileNames(path):
	names = []
	for dirname, dirnames, filenames in os.walk(path):
		for filename in filenames:
			if filename.endswith("srn"):
				names.append(os.path.join(dirname, filename))
	return names

print networkFileNames(r"E:\scirun\trunk_ref\SCIRun\src\nets")

def moduleLines(file):
	modLines = []
	for line in open(file, 'r'):
		if line.find("<module ") != -1:
			modLines.append(line)
	return modLines


	
testFile = r"E:\scirun\trunk_ref\SCIRun\src\nets\FwdInvToolbox\activation-based-fem\activation-based-fem.srn"
ml = moduleLines(testFile)

sampleLine = ml[0]

nameAttr = "name=\""

def grabModuleNameFromLine(line):
    start = line.find(nameAttr)
    end = line.find("\"", start + len(nameAttr))
    return line[(start + len(nameAttr)):end]

grabModuleNameFromLine(sampleLine)

def modulesInNetworkFile(file):
	modules = []
	for line in moduleLines(file):
		modules.append(grabModuleNameFromLine(line))
	return modules

modulesInNetworkFile(testFile)

def moduleCountDictionary(file):
	list = modulesInNetworkFile(file)
	return {mod : list.count(mod) for mod in list}


dict = moduleCountDictionary(testFile)
print dict

def moduleLinesMany(files):
	modLines = []
	for file in files:
		modLines += moduleLines(file)
	return modLines
	
def modulesInNetworkFileMany(files):
	modules = []
	for line in moduleLinesMany(files):
		modules.append(grabModuleNameFromLine(line))
	return modules

def moduleCountDictionaryMany(files):
	list = modulesInNetworkFileMany(files)
	return {mod : list.count(mod) for mod in list}

modFreq = moduleCountDictionaryMany(networkFileNames(r"E:\scirun\trunk_ref\SCIRun\src\nets"))

modsSortedByFreq = sorted(modFreq.items(), key=lambda x: x[1], reverse=True)

print modsSortedByFreq[:10]